namespace GymCraftAPI.Application.DTOs.Workout;

public record WorkoutDTO
{
    public required Guid Uuid { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public required bool IsActive { get; init; }
    public required Guid UserUuid { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
