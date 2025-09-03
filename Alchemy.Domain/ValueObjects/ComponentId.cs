namespace Alchemy.Domain.ValueObjects;

public record ComponentId
{
    public Guid Value { get; }

    public ComponentId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Component Id не может быть пустым", nameof(value));
        
        Value = value;
    }
    
    public static ComponentId New() => new ComponentId(Guid.CreateVersion7()); 
    
    public override string ToString() => Value.ToString();
    
}