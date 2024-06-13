using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllActiveAsync();
    Task<User?> GetActiveByIdAsync(Guid userUuid);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task SoftDeleteAsync(Guid userUuid);
}
