namespace GymCraftAPI.Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}
