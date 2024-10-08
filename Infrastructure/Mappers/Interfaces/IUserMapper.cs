using GymCraftAPI.Application.DTOs.User;
using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Mappers.Interfaces;

public interface IUserMapper
{
    User MapToEntity(CreateUserDTO userDto);
    UserDTO MapToDto(User user);
    IEnumerable<UserDTO> MapToDto(IEnumerable<User> users);
}
