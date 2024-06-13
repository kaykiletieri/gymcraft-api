using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IExerciseService
{
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetByIdAsync(Guid exerciseUuid);
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<Exercise> UpdateAsync(Exercise exercise);
    Task SoftDeleteAsync(Guid exerciseUuid);
}
