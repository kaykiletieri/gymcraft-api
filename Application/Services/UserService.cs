using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllActiveAsync();
    }

    public async Task<User?> GetByIdAsync(Guid userUuid)
    {
        return await _userRepository.GetActiveByIdAsync(userUuid);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task SoftDeleteAsync(Guid userUuid)
    {
        await _userRepository.SoftDeleteAsync(userUuid);
    }
}
