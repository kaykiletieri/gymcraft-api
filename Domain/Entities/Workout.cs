namespace GymCraftAPI.Domain.Entities;

public class Workout : EntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ICollection<WorkoutDay> WorkoutDays { get; set; }
    public required bool IsActive { get; set; }
    public required Guid UserId { get; set; }
    public User? User { get; set; }
}
