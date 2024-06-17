using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid userUuid);
    Task<User> CreateAsync(CreateUserDTO userDto);
    Task<User> UpdateAsync(User user);
    Task SoftDeleteAsync(Guid userUuid);
}
