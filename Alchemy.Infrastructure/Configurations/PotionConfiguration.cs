using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alchemy.Infrastructure.Configurations;

public class PotionConfiguration : IEntityTypeConfiguration<Potion>
{
    public void Configure(EntityTypeBuilder<Potion> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(
                vo => vo.Value,
                v => new PotionId(v));
        

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired();

        builder
            .HasMany(p => p.Effects)
            .WithMany(e => e.Potions)
            .UsingEntity(j =>
            {
                j.IndexerProperty<Guid>("Id");
                j.HasKey("Id");
            });
    }
}