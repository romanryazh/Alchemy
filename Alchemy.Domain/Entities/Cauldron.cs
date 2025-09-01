namespace Alchemy.Domain.Entities;

public class Cauldron : EntityBase
{
    public string Name { get; set; } = string.Empty;
    
    public CraftingProcess? CraftingProcess { get; set; }
    
    private Cauldron() { }
    
    
}