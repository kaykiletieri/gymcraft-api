using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IExerciseCategoryService
{
    Task<IEnumerable<ExerciseCategory>> GetAllAsync();
    Task<ExerciseCategory?> GetByIdAsync(Guid exerciseCategoryUuid);
    Task<ExerciseCategory> CreateAsync(ExerciseCategory exerciseCategory);
    Task<ExerciseCategory> UpdateAsync(ExerciseCategory exerciseCategory);
    Task SoftDeleteAsync(Guid exerciseCategoryUuid);
}
