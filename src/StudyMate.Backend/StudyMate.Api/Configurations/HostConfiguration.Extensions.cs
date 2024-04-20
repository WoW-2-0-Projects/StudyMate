﻿using Microsoft.EntityFrameworkCore;
using StudyMate.Domain.Constants;
using StudyMate.Infrastructure.Common.Settings;
using StudyMate.Persistence.DataContexts;

namespace StudyMate.Api.Configurations;

public static partial class HostConfiguration
{
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