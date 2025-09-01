using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Interfaces;

public interface IPotionRepository
{
    Task AddAsync(Potion potion, CancellationToken ct);
    
    Task UpdateAsync(Potion potion, CancellationToken ct);
    
    Task DeleteAsync(Potion potion, CancellationToken ct);
    
    Task<Potion?> GetByIdAsync(Guid id, CancellationToken ct);
    
    IQueryable<Potion> GetAll();
}