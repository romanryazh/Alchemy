using Alchemy.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alchemy.Infrastructure.Services;

public class UnitOfWork(AppDbContext context, IServiceProvider serviceProvider) : IUnitOfWork
{
    private IEffectRepository _effectRepository;
    private IPotionRepository _potionRepository;
    private ILocationRepository _locationRepository;
    private IComponentRepository _componentRepository;
    private ICraftStepRepository _craftStepRepository;

    public IEffectRepository EffectRepository => _effectRepository ??=
        serviceProvider.GetRequiredService<IEffectRepository>();
    
    public IPotionRepository PotionRepository => _potionRepository ??=
        serviceProvider.GetRequiredService<IPotionRepository>();
    
    public ILocationRepository LocationRepository => _locationRepository ??=
        serviceProvider.GetRequiredService<ILocationRepository>();

    public IComponentRepository ComponentRepository => _componentRepository ??=
        serviceProvider.GetRequiredService<IComponentRepository>();    
    
    public ICraftStepRepository CraftStepRepository => _craftStepRepository ??=
        serviceProvider.GetRequiredService<ICraftStepRepository>();

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await context.SaveChangesAsync(ct);
    }

    public void Dispose()
    {
        context.Dispose();
    }
}