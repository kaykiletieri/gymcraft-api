namespace GymCraftAPI.Application.DTOs.ExerciseCategory;

public record CreateExerciseCategoryDTO
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
