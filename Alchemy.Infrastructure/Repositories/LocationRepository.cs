using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Repositories;

public class LocationRepository(AppDbContext context) : ILocationRepository
{
    public async Task AddAsync(Location location, CancellationToken ct)
    {
        await context.Locations.AddAsync(location, ct);
    }

    public Task UpdateAsync(Location location, CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Location location, CancellationToken ct)
    {
        context.Locations.Remove(location);
    }

    public async Task<Location?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var locationId = new LocationId(id);
        return await context.Locations.FirstOrDefaultAsync(l => l.Id == locationId, ct);
    }

    public Task<IQueryable<Location>> GetAll()
    {
        return Task.FromResult(context.Locations.AsQueryable());
    }
}