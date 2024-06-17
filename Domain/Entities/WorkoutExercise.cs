namespace GymCraftAPI.Domain.Entities;

public class WorkoutExercise : EntityBase
{
    public required Guid ExerciseUuid { get; set; }
    public Exercise? Exercise { get; set; }
    public required Guid WorkoutDayUuid { get; set; }
    public WorkoutDay? WorkoutDay { get; set; }
    public required int Sets { get; set; }
    public required int Repetitions { get; set; }
    public int? RestTime { get; set; }
    public string? Notes { get; set; }
}
