namespace Alchemy.Domain.ValueObjects;

public record EffectId
{
    public Guid Value { get; }
    
    public EffectId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Effect Id не может быть пустым", nameof(value));
        }
        
        Value = value;
    }

    public static EffectId New()
    {
        return new EffectId(Guid.CreateVersion7());
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}