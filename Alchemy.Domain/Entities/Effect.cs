using System.ComponentModel.DataAnnotations;
using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Entities;

public class Effect : EntityBase
{
    public EffectId Id { get; set; }
    
    public string Name { get; set; } 
    
    public string Description { get; set; } 
 
    private List<Potion> _potions;
    
    public IReadOnlyCollection<Potion> Potions => _potions.AsReadOnly();
    
    private Effect() {}

    private Effect(string name, string description)
    {
        Id = EffectId.New();
        Name = name;
        Description = description;
        _potions = new List<Potion>();
    }

    public void Update(string name, string description)
    {
        // инварианты
        
        Name = name;
        Description = description;
    }
    
    public static Effect Create(string name, string description)
    {
        // инварианты
        
        return new Effect(name, description);
    }
}