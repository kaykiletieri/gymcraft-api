using GymCraftAPI.Application.DTOs.Exercise;

namespace GymCraftAPI.Application.DTOs.WorkoutExercise;

public record WorkoutExerciseDTO
{
    public required Guid Guid { get; init; }
    public required Guid ExerciseUuid { get; init; }
    public required ExerciseDTO Exercise { get; init; }
    public required Guid WorkoutDayUuid { get; init; }
    public required int Sets { get; init; }
    public required int Repetitions { get; init; }
    public int? RestTime { get; init; }
    public string? Notes { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
