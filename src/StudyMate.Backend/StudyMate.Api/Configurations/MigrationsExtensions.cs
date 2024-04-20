using Microsoft.EntityFrameworkCore;

namespace StudyMate.Api.Configurations;

public static class MigrationExtensions
{
    /// <summary>
    /// Migrates the database associated with the specified context.
    /// </summary>
    /// <typeparam name="TContext">Data access context.</typeparam>
    /// <param name="scopeFactory">Service scope factory.</param>
    /// <returns></returns>
    public static async ValueTask MigrateAsync<TContext>(this IServiceScopeFactory scopeFactory) where TContext : DbContext
    {
        await using var scope = scopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
            await context.Database.MigrateAsync();
    }
}