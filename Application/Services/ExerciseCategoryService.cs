using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class ExerciseCategoryService : IExerciseCategoryService
{
    private readonly IExerciseCategoryRepository _exerciseCategoryRepository;

    public ExerciseCategoryService(IExerciseCategoryRepository exerciseCategoryRepository)
    {
        _exerciseCategoryRepository = exerciseCategoryRepository;
    }

    public async Task<IEnumerable<ExerciseCategory>> GetAllAsync()
    {
        return await _exerciseCategoryRepository.GetAllActiveAsync();
    }

    public async Task<ExerciseCategory?> GetByIdAsync(Guid exerciseCategoryUuid)
    {
        return await _exerciseCategoryRepository.GetActiveByIdAsync(exerciseCategoryUuid);
    }

    public async Task<ExerciseCategory> CreateAsync(ExerciseCategory exerciseCategory)
    {
        return await _exerciseCategoryRepository.CreateAsync(exerciseCategory);
    }

    public async Task<ExerciseCategory> UpdateAsync(ExerciseCategory exerciseCategory)
    {
        return await _exerciseCategoryRepository.UpdateAsync(exerciseCategory);
    }

    public async Task SoftDeleteAsync(Guid exerciseCategoryUuid)
    {
        await _exerciseCategoryRepository.SoftDeleteAsync(exerciseCategoryUuid);
    }
}
