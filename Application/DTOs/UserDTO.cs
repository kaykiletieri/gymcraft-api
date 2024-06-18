namespace GymCraftAPI.Application.DTOs;

public record UserDTO
{
    public required Guid Uuid { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
