using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Entities;

public class Component : EntityBase
{
    public ComponentId Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public decimal Price { get; private set; }
    
    private List<Effect> _effects;
    
    public IReadOnlyCollection<Effect> Effects => _effects.AsReadOnly();

    private List<Location> _locations;
    
    public IReadOnlyCollection<Location> Locations => _locations.AsReadOnly();
    
    private Component() {}

    private Component(string name, string description, decimal price)
    {
        Id = ComponentId.New();
        Name = name;
        Description = description;
        Price = price;
        _effects = new List<Effect>();
        _locations = new List<Location>();
    }

    public static Component Create(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Название не может быть пустым");

        if (price < 0)
            throw new ArgumentException($"Стоимость не может быть меньше 0");

        return new Component(name, description, price);
    }

    public void AddEffect(Effect effect)
    {
        _effects.Add(effect);
    }

    public void AddLocation(Location location)
    {
        _locations.Add(location);
    }

    public List<Effect> GetEffects()
    {
        return _effects;
    }

    public List<Location> GetLocations()
    {
        return _locations;
    }
    
    
    
}