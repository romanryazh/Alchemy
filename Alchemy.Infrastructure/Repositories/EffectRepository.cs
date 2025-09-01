using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Repositories;

public class EffectRepository(AppDbContext context) : IEffectRepository
{
    public async Task AddAsync(Effect entity, CancellationToken ct)
    {
        await context.Effects.AddAsync(entity, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Effect entity, CancellationToken ct)
    {
        context.Effects.Update(entity);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Effect entity, CancellationToken ct)
    {
        context.Effects.Remove(entity);
        await context.SaveChangesAsync(ct);
    }

    public async Task<Effect?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var effectId = new EffectId(id);
        return await context.Effects.FirstOrDefaultAsync(e => e.Id == effectId, ct);
    }

    public IQueryable<Effect> GetAll()
    {
        return context.Effects.AsQueryable();
    }
}