namespace GymCraftAPI.Domain.ValueObjects;

public class Name
{
    public string Value { get; private set; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Name) return false;
        return ((Name)obj).Value == this.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
