using Microsoft.EntityFrameworkCore;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    #region Question Generation Infrastructure
    
    private DbSet<Answer> Answers => Set<Answer>();
    
    public DbSet<Question> Questions => Set<Question>();

    public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions => Set<MultipleChoiceQuestion>();

    public DbSet<MultipleChoiceQuestionAnswer> MultipleChoiceAnswers => Set<MultipleChoiceQuestionAnswer>();

    public DbSet<TrueFalseQuestion> TrueFalseQuestions => Set<TrueFalseQuestion>();

    public DbSet<TrueFalseQuestionAnswer> TrueFalseAnswers => Set<TrueFalseQuestionAnswer>();

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}