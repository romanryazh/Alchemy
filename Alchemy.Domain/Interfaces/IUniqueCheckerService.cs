namespace Alchemy.Domain.Interfaces;

public interface IUniqueCheckerService
{
    Task<bool> IsUniqueAsync<TEntity>(string propertyName, object value,
        CancellationToken cancellationToken = default) where TEntity : class;

    Task<bool> IsUniqueAsync<TEntity>(string propertyName, object value, object? excludeId,
        CancellationToken cancellationToken = default) where TEntity : class;
}