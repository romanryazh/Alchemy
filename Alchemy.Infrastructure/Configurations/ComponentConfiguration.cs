using Alchemy.Application.Effects.DTOs;
using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alchemy.Infrastructure.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasConversion(
                vo => vo.Value,
                o => new ComponentId(o));

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.Description).IsRequired();

        builder.Property(c => c.Price).IsRequired();

        builder
            .HasMany(c => c.Effects)
            .WithMany(e => e.Components);

        builder
            .HasMany(c => c.Locations)
            .WithMany(l => l.Components);
    }
}