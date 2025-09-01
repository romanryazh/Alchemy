namespace Alchemy.Domain.Entities;

public class CraftStep : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Order { get; set; }
    
    private List<Component> _components;
    
    public IReadOnlyCollection<Component> Components => _components.AsReadOnly();
    
    private CraftStep() {}
    
    
}