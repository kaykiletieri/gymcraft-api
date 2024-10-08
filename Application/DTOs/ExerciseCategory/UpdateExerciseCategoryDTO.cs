namespace GymCraftAPI.Application.DTOs.ExerciseCategory;

public record UpdateExerciseCategoryDTO
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}
