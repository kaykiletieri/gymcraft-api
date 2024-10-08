using GymCraftAPI.Application.DTOs.User;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<UserDTO?> GetByIdAsync(Guid userUuid);
    Task<UserDTO> CreateAsync(CreateUserDTO userDto);
    Task<UserDTO> UpdateAsync(Guid userUuid, UpdateUserDTO userDto);
    Task SoftDeleteAsync(Guid userUuid);
}
