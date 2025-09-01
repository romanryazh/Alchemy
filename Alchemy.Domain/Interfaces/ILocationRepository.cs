using Alchemy.Domain.Entities;

namespace Alchemy.Domain.Interfaces;

public interface ILocationRepository
{
    Task AddAsync(Location location, CancellationToken ct);
    
    Task UpdateAsync(Location location, CancellationToken ct);
    
    Task DeleteAsync(Location location, CancellationToken ct);
    
    Task<Location?> GetByIdAsync(Guid id, CancellationToken ct);
    
    Task<IQueryable<Location>> GetAll();
}
