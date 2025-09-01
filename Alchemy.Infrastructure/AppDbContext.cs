using Microsoft.EntityFrameworkCore;
using Alchemy.Infrastructure.Configurations;
using Alchemy.Domain.Entities;

namespace Alchemy.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
    public DbSet<Effect> Effects => Set<Effect>();
    
    public DbSet<Potion> Potions => Set<Potion>();
    
    public DbSet<Location> Locations => Set<Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EffectConfiguration());
        modelBuilder.ApplyConfiguration(new PotionConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}