namespace GymCraftAPI.Application.DTOs.WorkoutExercise;

public record UpdateWorkExerciseDTO
{
    public Guid? ExerciseUuid { get; init; }
    public Guid? WorkoutDayUuid { get; init; }
    public int? Sets { get; init; }
    public int? Repetitions { get; init; }
    public int? RestTime { get; init; }
    public string? Notes { get; init; }
}
