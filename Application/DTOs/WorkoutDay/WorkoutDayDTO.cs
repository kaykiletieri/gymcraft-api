using GymCraftAPI.Application.DTOs.WorkoutExercise;
using GymCraftAPI.Domain.Enums;

namespace GymCraftAPI.Application.DTOs.WorkoutDay;

public record WorkoutDayDTO
{
    public required Guid Uuid { get; init; }
    public required WeekDay WeekDay { get; init; }
    public required Guid WorkoutUuid { get; init; }
    public ICollection<WorkoutExerciseDTO>? WorkoutExercises { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}