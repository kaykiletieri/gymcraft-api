namespace GymCraftAPI.Application.DTOs;

public record CreateExerciseCategoryDTO
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
