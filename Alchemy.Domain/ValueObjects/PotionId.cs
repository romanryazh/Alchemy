namespace Alchemy.Domain.ValueObjects;

public record PotionId
{
    public Guid Value { get; }
    
    public PotionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Potion Id не может быть пустым", nameof(value));
        }
        
        Value = value;
    }

    public static PotionId New()
    {
        return new PotionId(Guid.CreateVersion7());
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}