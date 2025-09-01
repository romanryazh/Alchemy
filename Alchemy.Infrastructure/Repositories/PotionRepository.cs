using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Repositories;

public class PotionRepository(AppDbContext context) : IPotionRepository
{
    public async Task AddAsync(Potion potion, CancellationToken ct)
    {
        await context.Potions.AddAsync(potion, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Potion potion, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Potion potion, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<Potion?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var potionId = new PotionId(id);
        return await context.Potions
            .Include(p => p.Effects)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == potionId, ct);
    }

    public IQueryable<Potion> GetAll()
    {
        throw new NotImplementedException();
    }
}