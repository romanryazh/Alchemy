using Alchemy.Domain.Entities;

namespace Alchemy.Domain.Interfaces;

public interface IComponentRepository
{
    Task AddAsync(Component component, CancellationToken ct);
    
    Task UpdateAsync(Component component, CancellationToken ct);
    
    Task DeleteAsync(Component component, CancellationToken ct);
    
    Task<Component?> GetByIdAsync(Guid id, CancellationToken ct);
    
    Task<IQueryable<Component>> GetAll();
}