namespace GymCraftAPI.Domain.Entities;

public class ExerciseCategory : EntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}
