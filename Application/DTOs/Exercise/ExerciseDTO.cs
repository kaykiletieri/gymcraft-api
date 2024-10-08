namespace GymCraftAPI.Application.DTOs.Exercise;

public record ExerciseDTO
{
    public required Guid Uuid { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Guid CategoryUuid { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}
