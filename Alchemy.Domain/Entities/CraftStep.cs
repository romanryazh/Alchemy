using Alchemy.Domain.ValueObjects;

namespace Alchemy.Domain.Entities;

public class CraftStep : EntityBase
{
    public CraftStepId Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Order { get; set; }
    
    private List<Component> _components;
    
    public IReadOnlyCollection<Component> Components => _components.AsReadOnly();
    
    private CraftStep() {}

    private CraftStep(string name, string description, int order)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название этапа крафта не может быть пустым");

        if (order <= 0)
            throw new ArgumentException("порядковый номер не может быть меньше 1");
        
        Id = CraftStepId.New();
        Name = name;
        Description = description;
        Order = order;
        
        _components = new List<Component>();
    }

    public static CraftStep Create(string name, string description, int order)
    {
        return new CraftStep(name, description, order);
    }

    public void AddComponent(Component component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        _components.Remove(component);
    }

    public List<Component> GetComponents()
    {
        return _components;
    }
}