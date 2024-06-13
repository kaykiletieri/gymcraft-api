namespace GymCraftAPI.Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}
