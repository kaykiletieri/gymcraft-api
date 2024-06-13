using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Repositories.Interfaces;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllActiveAsync();
    Task<Exercise?> GetActiveByIdAsync(Guid exerciseUuid);
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<Exercise> UpdateAsync(Exercise exercise);
    Task SoftDeleteAsync(Guid exerciseUuid);
}
