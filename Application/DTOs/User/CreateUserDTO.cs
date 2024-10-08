﻿namespace GymCraftAPI.Application.DTOs.User;

public record CreateUserDTO
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}
