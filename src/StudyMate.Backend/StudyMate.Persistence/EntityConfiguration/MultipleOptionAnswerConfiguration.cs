using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.EntityConfiguration;

public class MultipleOptionAnswerConfiguration:IEntityTypeConfiguration<MultipleOptionAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleOptionAnswer> builder)
    {
        
    }
}