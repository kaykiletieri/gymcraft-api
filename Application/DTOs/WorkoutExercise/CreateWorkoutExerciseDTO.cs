namespace GymCraftAPI.Application.DTOs.WorkoutExercise;

public record CreateWorkoutExerciseDTO
{
    public required Guid ExerciseUuid { get; init; }
    public required Guid WorkoutDayUuid { get; init; }
    public required int Sets { get; init; }
    public required int Repetitions { get; init; }
    public int? RestTime { get; init; }
    public string? Notes { get; init; }
}
