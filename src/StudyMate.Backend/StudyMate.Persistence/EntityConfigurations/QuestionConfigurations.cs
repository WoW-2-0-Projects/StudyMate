using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.EntityConfigurations;

public class QuestionConfigurations : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(question => question.Type).HasConversion<string>().HasMaxLength(64).IsRequired();
        builder.Property(question => question.QuestionContent).HasMaxLength(1_036_288).IsRequired();
    }
}