namespace GymCraftAPI.Domain.ValueObjects;

public class Email
{
    public string Value { get; private set; }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value) || !value.Contains('@'))
        {
            throw new ArgumentException("Invalid email.");
        }

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Email) return false;
        return ((Email)obj).Value == this.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}

