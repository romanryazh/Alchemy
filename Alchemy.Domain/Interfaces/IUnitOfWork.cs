namespace Alchemy.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEffectRepository EffectRepository { get; }
    IPotionRepository PotionRepository { get; }
    ILocationRepository LocationRepository { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken ct = default);
    
    
}