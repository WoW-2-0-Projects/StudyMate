namespace StudyMate.Api.Configurations;

public static partial class HostConfiguration
{
    /// <summary>
    /// Configures application builder
    /// </summary>
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistence()
            .AddCors()
            .AddDevTools()
            .AddExposers();
            
        return new(builder);
    }
    
    /// <summary>
    /// Configures application
    /// </summary>
    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.MigrateDataBaseSchemasAsync();
        
        app
            .UseCors()
            .UseDevTools()
            .UseExposers();

        return app;
    }
}