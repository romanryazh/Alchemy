using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Entities;

public class Potion : EntityBase
{
    public PotionId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    private List<Effect> _effects;
    
    public IReadOnlyCollection<Effect> Effects => _effects.AsReadOnly();

    private Potion()
    {
    }

    private Potion(string name, string description)
    {
        Id = PotionId.New();
        Name = name;
        Description = description;
        _effects = new List<Effect>();
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddEffect(Effect effect)
    {
        if (!_effects.Contains(effect))
        {
            _effects.Add(effect);
        }
    }

    public List<Effect> GetEffects()
    {
        return _effects;
    } 

    public static Potion Create(string name, string description)
    {
        return new Potion(name, description);
    }
    
}