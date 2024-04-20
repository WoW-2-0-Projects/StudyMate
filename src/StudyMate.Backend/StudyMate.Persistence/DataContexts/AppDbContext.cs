using Microsoft.EntityFrameworkCore;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<MultipleOptionAnswer> MultipleOptionAnswers => Set<MultipleOptionAnswer>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}