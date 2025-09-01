using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Entities;

public class Location : EntityBase
{
    public LocationId Id { get; private set; }
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    private Location() {}

    private Location(string name, string description)
    {
        Id = LocationId.New();
        Name = name;
        Description = description;
    }

    public static Location Create(string name, string description)
    {
        return new Location(name, description);
    }
}