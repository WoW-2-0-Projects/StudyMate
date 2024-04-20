using Microsoft.EntityFrameworkCore;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<MultipleOptionAnswer> MultipleOptionAnswers => Set<MultipleOptionAnswer>();
    
    public DbSet<Question> Questions => Set<Question>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}