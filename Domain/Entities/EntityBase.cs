namespace GymCraftAPI.Domain.Entities;

public abstract class EntityBase
{
    public Guid Uuid { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; private set; }

    protected EntityBase()
    {
        Uuid = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateTimestamps()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
        UpdateTimestamps();
    }

    public void Restore()
    {
        DeletedAt = null;
        UpdateTimestamps();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase other)
            return false;

        return Uuid == other.Uuid;
    }

    public override int GetHashCode()
    {
        return Uuid.GetHashCode();
    }
}
