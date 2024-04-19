using StudyMate.Domain.Constants;
using StudyMate.Infrastructure.Common.Settings;

namespace StudyMate.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        // Register settings
        builder.Services.Configure<CoreSettings>(builder.Configuration.GetSection(nameof(CoreSettings)));
        var corsSettings = builder.Configuration.GetSection(nameof(CoreSettings)).Get<CoreSettings>()
                           ?? throw new HostAbortedException("Cors settings are not configured");
        
        builder.Services.AddCors(options => options.AddPolicy(HostConstants.AllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins(corsSettings.AllowedOrigins);
                    
                if(corsSettings.AllowAnyHeaders)
                    policy.AllowAnyHeader();
                
                if(corsSettings.AllowAnyMethods)
                    policy.AllowAnyMethod();
                
                if(corsSettings.AllowCredentials)
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
        app.UseCors(HostConstants.AllowSpecificOrigins);
        
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