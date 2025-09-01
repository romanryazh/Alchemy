using Alchemy.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Infrastructure.Services;

public class UniqueCheckerService(AppDbContext context) : IUniqueCheckerService
{
    public async Task<bool> IsUniqueAsync<TEntity>(string propertyName, object value,
        CancellationToken ct = default) where TEntity : class
    {
        return !await context.Set<TEntity>()
            .AnyAsync(e => EF.Property<object>(e, propertyName) == value, ct);
    }

    // public async Task<bool> IsUniqueAsync<TEntity>(string propertyName, object value, object? excludeId,
    //     CancellationToken ct = default) where TEntity : class
    // {
    //     var query = context.Set<TEntity>()
    //         .Where(e => EF.Property<object>(e, propertyName) == value);
    //
    //     if (excludeId != null)
    //     {
    //         query = query.Where(e => !EF.Property<object>(e, "Id").Equals(excludeId));
    //     }
    //     
    //     return await query.AnyAsync(ct);
    // }
    public async Task<bool> IsUniqueAsync<TEntity>(string propertyName, object value, object? excludeId,
        CancellationToken ct = default) where TEntity : class
    {
        return !await context.Set<TEntity>()
            .AnyAsync(e => EF.Property<object>(e, propertyName).Equals(value) &&
                (excludeId == null || !EF.Property<object>(e, "Id").Equals(excludeId)), ct);
    }
}