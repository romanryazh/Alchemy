using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alchemy.Infrastructure.Configurations;

public class EffectConfiguration : IEntityTypeConfiguration<Effect>
{
    public void Configure(EntityTypeBuilder<Effect> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasConversion(
                vo => vo.Value,
                v => new EffectId(v));
        
        builder.Property(e => e.Name)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .IsRequired();
    }
}