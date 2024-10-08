namespace GymCraftAPI.Application.DTOs.ExerciseCategory;

public record ExerciseCategoryDTO
{
    public required Guid Uuid { get; init; }
    public required string CategoryName { get; init; }
    public string? Description { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
