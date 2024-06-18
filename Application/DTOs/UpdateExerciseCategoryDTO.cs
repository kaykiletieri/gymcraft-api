namespace GymCraftAPI.Application.DTOs;

public record UpdateExerciseCategoryDTO
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}
