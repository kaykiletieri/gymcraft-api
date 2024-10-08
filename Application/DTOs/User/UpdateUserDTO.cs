namespace GymCraftAPI.Application.DTOs.User;

public record UpdateUserDTO
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
}
