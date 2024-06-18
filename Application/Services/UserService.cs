using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Helpers;
using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;
    private readonly IPropertyUpdater _propertyUpdater;

    public UserService(IUserRepository userRepository, IUserMapper userMapper, IPropertyUpdater propertyUpdater)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
        _propertyUpdater = propertyUpdater;
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        IEnumerable<User> users = await _userRepository.GetAllActiveAsync();

        return _userMapper.MapToDto(users);
    }

    public async Task<UserDTO?> GetByIdAsync(Guid userUuid)
    {
        User? user = await _userRepository.GetActiveByIdAsync(userUuid);

        return user != null ? _userMapper.MapToDto(user) : null;
    }

    public async Task<UserDTO> CreateAsync(CreateUserDTO userDto)
    {
        User user = _userMapper.MapToEntity(userDto);

        User createdUser = await _userRepository.CreateAsync(user);

        return _userMapper.MapToDto(createdUser);
    }

    public async Task<UserDTO> UpdateAsync(Guid userUuid, UpdateUserDTO userDto)
    {
        User user = await _userRepository.GetActiveByIdAsync(userUuid) ?? throw new KeyNotFoundException("User not found");

        _propertyUpdater.UpdatePropertyIfNotEmpty(value => user.Name = value, userDto.Name);
        _propertyUpdater.UpdatePropertyIfNotEmpty(value => user.Email = value, userDto.Email);
        _propertyUpdater.UpdatePropertyIfNotEmpty(value => user.PasswordHash = value, userDto.Password);

        user.UpdatedAt = DateTime.UtcNow;

        User updatedUser = await _userRepository.UpdateAsync(user);

        return _userMapper.MapToDto(updatedUser);
    }


    public async Task SoftDeleteAsync(Guid userUuid)
    {
        await _userRepository.SoftDeleteAsync(userUuid);
    }
}
