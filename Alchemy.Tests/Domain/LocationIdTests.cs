using Alchemy.Domain.ValueObjects;

namespace Alchemy.Tests.Domain;

public class LocationIdTests
{
    [Fact]
    public void LocationId_GuidEmpty_ThrowsArgumentException()
    {
        var emptyGuid = Guid.Empty;
        
        Assert.Throws<ArgumentException>(() => new LocationId(emptyGuid));
    }
    
    
}