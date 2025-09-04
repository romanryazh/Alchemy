using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Component = System.ComponentModel.Component;

namespace Alchemy.Infrastructure.Configurations;

public class CraftStepConfiguration : IEntityTypeConfiguration<CraftStep>
{
    public void Configure(EntityTypeBuilder<CraftStep> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasConversion(
                vo => vo.Value,
                v => new CraftStepId(v));

        builder.Property(s => s.Name).HasMaxLength(50).IsRequired();

        builder.Property(s => s.Description).HasMaxLength(100).IsRequired();

        builder
            .HasMany(s => s.Components)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "CraftStepComponent",
                j => j.HasOne<Alchemy.Domain.Entities.Component>().WithMany().HasForeignKey("ComponentId"),
                j => j.HasOne<CraftStep>().WithMany().HasForeignKey("CraftStepId"),
                j => j.HasKey("CraftStepId", "ComponentId")
            );
    }
}