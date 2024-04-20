using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;
using StudyMate.Domain.Enums;

namespace StudyMate.Persistence.EntityConfiguration;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        // builder
            // .HasDiscriminator(answer => answer.Type)
            // .HasValue<MultipleChoiceQuestionAnswer>(QuestionType.MultipleChoice)
            // .HasValue<TrueFalseQuestionAnswer>(QuestionType.TrueFalseQuestion);

        builder.UseTptMappingStrategy();
    }
}