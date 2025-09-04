using Alchemy.Domain.Interfaces;
using Alchemy.Infrastructure.Repositories;
using Alchemy.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Alchemy.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b =>
                {
                    b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                })
            );

        // services.AddScoped<AppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IEffectRepository, EffectRepository>();
        services.AddScoped<IPotionRepository, PotionRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IComponentRepository, ComponentRepository>();
        services.AddScoped<ICraftStepRepository, CraftStepRepository>();
        
        services.AddScoped<IUniqueCheckerService, UniqueCheckerService>();
        
        return services;
    }
}