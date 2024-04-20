namespace StudyMate.Api.Configurations;

public static partial class HostConfiguration
{
    /// <summary>
    /// Configures application builder
    /// </summary>
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddCors()
            .AddDevTools()
            .AddExposers();
            
        return new(builder);
    }
    
    /// <summary>
    /// Configures application
    /// </summary>
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseCors()
            .UseDevTools()
            .UseExposers();
        
        return new ValueTask<WebApplication>(app);
    }
}