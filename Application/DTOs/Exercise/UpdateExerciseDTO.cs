namespace GymCraftAPI.Application.DTOs.Exercise;

public record UpdateExerciseDTO
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public Guid? CategoryUuid { get; init; }
}
