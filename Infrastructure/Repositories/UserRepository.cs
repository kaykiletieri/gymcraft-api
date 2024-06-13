using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<User> _repositoryBase;

    public UserRepository(ApplicationDbContext context, IRepositoryBase<User> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<User>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<User?> GetActiveByIdAsync(Guid userUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(userUuid);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _repositoryBase.CreateAsync(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await _repositoryBase.UpdateAsync(user);
    }

    public async Task SoftDeleteAsync(Guid userUuid)
    {
        await _repositoryBase.SoftDeleteAsync(userUuid);
    }
}
