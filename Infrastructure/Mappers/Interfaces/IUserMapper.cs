using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Mappers.Interfaces;

public interface IUserMapper
{
    User MapToEntitie(CreateUserDTO userDto);
}
