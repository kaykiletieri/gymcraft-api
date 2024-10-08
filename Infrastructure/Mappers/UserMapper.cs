using GymCraftAPI.Application.DTOs.User;
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

    public UserDTO MapToDto(User user)
    {
        return new UserDTO
        {
            Uuid = user.Uuid,
            Name = user.Name,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };
    }

    public IEnumerable<UserDTO> MapToDto(IEnumerable<User> users)
    {
        return users.Select(MapToDto);
    }
}
