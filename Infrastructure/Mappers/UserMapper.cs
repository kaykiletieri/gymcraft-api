using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;

namespace GymCraftAPI.Infrastructure.Mappers;

public class UserMapper : IUserMapper
{
    public User MapToEntity(CreateUserDTO userDto)
    {
        return new User
        {
            Uuid = Guid.NewGuid(),
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = userDto.Password,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}
