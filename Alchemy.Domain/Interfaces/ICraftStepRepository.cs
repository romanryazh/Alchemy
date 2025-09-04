using Alchemy.Domain.Entities;

namespace Alchemy.Domain.Interfaces;

public interface ICraftStepRepository
{
    Task AddAsync(CraftStep step, CancellationToken ct);
    
    Task UpdateAsync(CraftStep step, CancellationToken ct);
    
    Task DeleteAsync(CraftStep step, CancellationToken ct);
    
    Task<CraftStep?> GetByIdAsync(Guid id, CancellationToken ct);
    
    Task<IQueryable<CraftStep>> GetAll();
}