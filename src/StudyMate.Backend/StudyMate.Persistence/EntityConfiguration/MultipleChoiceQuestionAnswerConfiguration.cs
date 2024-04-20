using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.EntityConfiguration;

public class MultipleChoiceQuestionAnswerConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceQuestionAnswer> builder)
    {
        builder
            .HasOne(answer => answer.Question)
            .WithOne(question => question.Answer)
            .HasForeignKey<MultipleChoiceQuestionAnswer>(answer => answer.QuestionId);
    }
}