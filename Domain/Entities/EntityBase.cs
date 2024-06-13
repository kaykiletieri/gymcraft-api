namespace GymCraftAPI.Domain.Entities;

public class EntityBase
{
    public required Guid Guid { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
