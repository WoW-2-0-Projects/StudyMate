using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.EntityConfiguration;

public class TrueFalseQuestionAnswerConfiguration : IEntityTypeConfiguration<TrueFalseQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<TrueFalseQuestionAnswer> builder)
    {
        builder
            .HasOne(answer => answer.Question)
            .WithOne(question => question.Answer)
            .HasForeignKey<TrueFalseQuestionAnswer>(answer => answer.QuestionId);
    }
}