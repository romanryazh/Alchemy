namespace Alchemy.Domain.Entities;

public class Location : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    private Location() {}
    
    
}