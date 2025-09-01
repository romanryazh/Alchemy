using Microsoft.EntityFrameworkCore;

namespace Alchemy.Application.Common;

public record PaginatedList<TEntity>
{
    public List<TEntity> Items { get; init; }
    public int PageIndex { get; init; }

    public int PageSize { get; init; }

    public int TotalCount { get; init; }
    public int TotalPages { get; init; }


    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedList(List<TEntity> items, int totalCount, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalPages = GetPageCount(totalCount, pageSize);
    }

    public static async Task<PaginatedList<TEntity>> PaginateAsync(IQueryable<TEntity> queryable, int pageIndex,
        int pageSize, CancellationToken ct)
    {
        if (queryable == null)
        {
            throw new ArgumentNullException(nameof(queryable));
        }

        var totalEntities = await queryable.CountAsync();

        if (pageSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize));
        }

        if (pageIndex <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageIndex));
        }
        
        if (pageIndex > GetPageCount(totalEntities, pageSize))
        {
            throw new ArgumentOutOfRangeException(nameof(PageIndex));
        }

        var entities = await queryable
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return new PaginatedList<TEntity>(entities, totalEntities, pageIndex, pageSize);
    }

    public PaginatedList<TResult> Map<TResult>(Func<TEntity, TResult> mapper)
    {
        var mappedItems = Items.Select(mapper).ToList();
        return new PaginatedList<TResult>(mappedItems, TotalCount, PageIndex, PageSize);
    }

    private static int GetPageCount(int totalCount, int pageSize)
    {
        var count = (int)Math.Ceiling(totalCount / (double)pageSize);
        return count > 0 ? count : 1;
    }
}