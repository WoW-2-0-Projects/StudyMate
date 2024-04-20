using MassTransit;
using Microsoft.EntityFrameworkCore;
using StudyMate.Application.Common.Serializers.Brokers;
using StudyMate.Domain.Constants;
using StudyMate.Infrastructure.Common.Caching;
using StudyMate.Infrastructure.Common.Serializers.Brokers;
using StudyMate.Infrastructure.Common.Settings;
using StudyMate.Persistence.Caching.Brokers;
using StudyMate.Persistence.DataContexts;
using StudyMate.Infrastructure.Common.EventBus.Extensions;
using System.Reflection;
using StudyMate.Application.Common.Events.Brokers;
using StudyMate.Infrastructure.Common.EventBus.Brokers;

namespace StudyMate.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies = Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies()
        .Select(Assembly.Load)
        .Append(Assembly.GetExecutingAssembly())
        .ToList();

    /// <summary>
    /// Registers persistence infrastructure
    /// </summary>
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        // Register data context
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(DataAccessConstants.DbConnectionString));
        });

        return builder;
    }

    /// <summary>
    /// Extension method for adding event bus services to the application.
    /// </summary>
    private static WebApplicationBuilder AddEventBus(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(
            configuration =>
            {
                var serviceProvider = configuration.BuildServiceProvider();
                var jsonSerializerSettingsProvider =
                    serviceProvider.GetRequiredService<IJsonSerializationSettingsProvider>();

                configuration.RegisterAllConsumers(Assemblies);
                configuration.UsingInMemory(
                    (context, cfg) =>
                    {
                        cfg.ConfigureEndpoints(context);

                        // Change default serializer to NewtonsoftJson
                        cfg.UseNewtonsoftJsonSerializer();
                        cfg.UseNewtonsoftJsonDeserializer();

                        // Change default serializer settings
                        cfg.ConfigureNewtonsoftJsonSerializer(settings =>
                            jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                        cfg.ConfigureNewtonsoftJsonDeserializer(settings =>
                            jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                    }
                );
            }
        );

        builder.Services.AddSingleton<IEventBusBroker, MassTransitEventBusBroker>();

        return builder;
    }

    /// <summary>
    /// Registers mapping services
    /// </summary>
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);
        return builder;
    }

    /// <summary>
    /// Registers mediatr infrastructure
    /// </summary>
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(conf => { conf.RegisterServicesFromAssemblies(Assemblies.ToArray()); });

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        // Register settings
        builder.Services.Configure<CorsSettings>(builder.Configuration.GetSection(nameof(CorsSettings)));
        var corsSettings = builder.Configuration.GetSection(nameof(CorsSettings)).Get<CorsSettings>()
                           ?? throw new HostAbortedException("Cors settings are not configured");

        // Register development CORS policy
        builder.Services.AddCors(options => options.AddPolicy(HostConstants.AllowAnyOrigins,
            policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        ));

        // Register production CORS policy
        builder.Services.AddCors(options => options.AddPolicy(HostConstants.AllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins(corsSettings.AllowedOrigins);

                if (corsSettings.AllowAnyHeaders)
                    policy.AllowAnyHeader();

                if (corsSettings.AllowAnyMethods)
                    policy.AllowAnyMethod();

                if (corsSettings.AllowCredentials)
                    policy.AllowCredentials();
            }
        ));

        return builder;
    }

    /// <summary>
    /// Registers developer tools
    /// </summary>
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();

        return builder;
    }

    /// <summary>
    /// Registers API exposers
    /// </summary>
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers().AddNewtonsoftJson();

        return builder;
    }

    /// <summary>
    /// Configures CORS settings
    /// </summary>
    private static WebApplication UseCors(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.UseCors(HostConstants.AllowAnyOrigins);
        else
            app.UseCors(HostConstants.AllowSpecificOrigins);

        return app;
    }

    /// <summary>
    /// Migrates database schemas
    /// </summary>
    private static async ValueTask<WebApplication> MigrateDataBaseSchemasAsync(this WebApplication app)
    {
        var serviceScopeFactory = app.Services.GetRequiredKeyedService<IServiceScopeFactory>(null);

        await serviceScopeFactory.MigrateAsync<AppDbContext>();

        return app;
    }

    ///<summary>
    /// Configures and adds Serializers to web application.
    /// </summary>
    private static WebApplicationBuilder AddSerializers(this WebApplicationBuilder builder)
    {
        // Register json serialization settings
        builder.Services.AddSingleton<IJsonSerializationSettingsProvider, JsonSerializationSettingsProvider>();

        return builder;
    }
    
    /// <summary>
    /// Registers caching
    /// </summary>
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        // Register settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        // Register cache brokers
        builder.Services.AddLazyCache().AddSingleton<ICacheBroker, LazyMemoryCacheBroker>();

        return builder;
    }
    

    /// <summary>
    /// Registers developer tools middlewares
    /// </summary>
    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    /// <summary>
    /// Registers exposer middlewares
    /// </summary>
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}