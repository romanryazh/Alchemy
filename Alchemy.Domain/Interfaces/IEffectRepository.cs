using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Interfaces;

public interface IEffectRepository
{
    Task AddAsync(Effect effect, CancellationToken ct);
    Task UpdateAsync(Effect effect, CancellationToken ct);
    Task DeleteAsync(Effect effect, CancellationToken ct);
    Task<Effect?> GetByIdAsync(Guid id, CancellationToken ct);
    IQueryable<Effect> GetAll();
}