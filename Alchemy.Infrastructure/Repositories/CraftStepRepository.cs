using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Repositories;

public class CraftStepRepository(AppDbContext context) : ICraftStepRepository
{
    public async Task AddAsync(CraftStep step, CancellationToken ct)
    {
        await context.CraftSteps.AddAsync(step, ct);
    }

    public Task UpdateAsync(CraftStep step, CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(CraftStep step, CancellationToken ct)
    {
        context.CraftSteps.Remove(step);
    }

    public async Task<CraftStep?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var stepId = new CraftStepId(id);
        return await context.CraftSteps
            .Include(s => s.Components)
            .ThenInclude(c => c.Effects)
            .Include(s => s.Components)
            .ThenInclude(c => c.Locations)
            .FirstOrDefaultAsync(s => s.Id == stepId, ct);
    }

    public Task<IQueryable<CraftStep>> GetAll()
    {
        return Task.FromResult(context.CraftSteps.AsQueryable());
    }
}