using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Domain.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> GetAllActiveAsync();
    Task<TEntity?> GetActiveByIdAsync(Guid uuid);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task SoftDeleteAsync(Guid uuid);
}
