namespace GymCraftAPI.Domain.Entities;

public class Exercise : EntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Guid CategoryUuid { get; set; }
    public ExerciseCategory? Category { get; set; }
    public required ICollection<WorkoutExercise> WorkoutExercises { get; set; }
}
