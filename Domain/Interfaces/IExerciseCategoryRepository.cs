using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Domain.Interfaces;

public interface IExerciseCategoryRepository
{
    Task<IEnumerable<ExerciseCategory>> GetAllActiveAsync();
    Task<ExerciseCategory?> GetActiveByIdAsync(Guid exerciseCategoryUuid);
    Task<ExerciseCategory> CreateAsync(ExerciseCategory exerciseCategory);
    Task<ExerciseCategory> UpdateAsync(ExerciseCategory exerciseCategory);
    Task SoftDeleteAsync(Guid exerciseCategoryUuid);
}
