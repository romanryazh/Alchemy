using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Repositories;

public class ComponentRepository(AppDbContext context) : IComponentRepository
{
    public async Task AddAsync(Component component, CancellationToken ct)
    {
        await context.Components.AddAsync(component, ct);
    }

    public Task UpdateAsync(Component component, CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Component component, CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    public async Task<Component?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var componentId = new ComponentId(id);
        return await context.Components
            .Include(c => c.Effects)
            .Include(c => c.Locations)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == componentId, ct); 
    }

    public Task<IQueryable<Component>> GetAll()
    {
        return Task.FromResult<IQueryable<Component>>(context.Components);
    }
}