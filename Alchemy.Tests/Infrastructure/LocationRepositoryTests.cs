using Alchemy.Domain.Entities;
using Alchemy.Infrastructure;
using Alchemy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alchemy.Tests.Infrastructure;

public class LocationRepositoryTests
{
    [Fact]
    public async Task AddAsync_SavesLocation()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        await using var dbContext = new AppDbContext(options);
        var repo = new LocationRepository(dbContext);

        var location = Location.Create("Локация", "Где-то");
        await repo.AddAsync(location, CancellationToken.None);
        await dbContext.SaveChangesAsync();
        
        var saved = await dbContext.Locations.FindAsync(location.Id);
        Assert.NotNull(saved);
        Assert.Equal("Локация", saved.Name);
    }
}