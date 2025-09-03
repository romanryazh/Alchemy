using Alchemy.Domain.Entities;

namespace Alchemy.Tests.Domain;

public class LocationTests
{
    [Fact]
    public void Create_ValidParameters_CreatesLocation()
    {
        var name = "пу-пу-пу";
        var description = "бла бла бла";
        
        var location = Location.Create(name, description);
        
        Assert.NotNull(location);
        Assert.NotEqual(Guid.Empty, location.Id.Value);
        Assert.Equal(name, location.Name);
        Assert.Equal(description, location.Description);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_EmptyName_ThrowsArgumentException(string invalidName)
    {
        var description = "бла бла бла";
        
        var exception = Assert.Throws<ArgumentException>(() => Location.Create(invalidName, description));
        Assert.Contains("Название не может быть пустым", exception.Message);
    }
    
    
}