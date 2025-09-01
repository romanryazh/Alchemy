namespace Alchemy.Domain.Entities;

public class Component : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    private List<Effect> _effects;
    
    public IReadOnlyCollection<Effect> Effects => _effects.AsReadOnly();

    private List<Location> _locations;
    
    public IReadOnlyCollection<Location> Locations => _locations.AsReadOnly();
    
    private Component() {}
    
    
}