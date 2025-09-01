namespace Alchemy.Domain.ValueObjects;

public class LocationId
{
    public Guid Value { get; }

    public LocationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Effect Id не может быть пустым", nameof(value));
        }
        
        Value = value;
    }

    public static LocationId New()
    {
        return new LocationId(Guid.CreateVersion7());
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }
}