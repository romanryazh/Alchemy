namespace Alchemy.Domain.ValueObjects;

public record CraftStepId
{
    public Guid Value { get; }

    public CraftStepId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("CraftStep Id не может быть пустым", nameof(value));
        }
        
        Value = value;
    }

    public static CraftStepId New()
    {
        return new CraftStepId(Guid.CreateVersion7());
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }
}