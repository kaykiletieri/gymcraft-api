using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public UserService(IUserRepository userRepository, IUserMapper userMapper)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllActiveAsync();
    }

    public async Task<User?> GetByIdAsync(Guid userUuid)
    {
        return await _userRepository.GetActiveByIdAsync(userUuid);
    }

    public async Task<User> CreateAsync(CreateUserDTO userDto)
    {
        User user = _userMapper.MapToEntity(userDto);

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
