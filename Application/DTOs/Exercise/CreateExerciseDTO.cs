namespace GymCraftAPI.Application.DTOs.Exercise;

public record CreateExerciseDTO
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required Guid CategoryUuid { get; init; }
}
