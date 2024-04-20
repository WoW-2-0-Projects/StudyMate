using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.EntityConfiguration;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(question => question.Type).HasConversion<string>().HasMaxLength(128).IsRequired();
        builder.Property(question => question.QuestionContent).HasMaxLength(4096).IsRequired();
    }
}