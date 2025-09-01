using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alchemy.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder
            .Property(l => l.Id)
            .HasConversion(
                vo => vo.Value,
                v => new LocationId(v));
        
        builder.Property(l => l.Description).IsRequired();
        
        builder.Property(l => l.Description).IsRequired();
    }
}