using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;
using StudyMate.Domain.Enums;

namespace StudyMate.Persistence.EntityConfiguration;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(question => question.QuestionContent).HasMaxLength(4096).IsRequired();

        builder
            .HasDiscriminator(question => question.TypeValue)
            .HasValue<MultipleChoiceQuestion>(QuestionType.MultipleChoice.ToString());
    }
}