using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _exerciseRepository.GetAllActiveAsync();
    }

    public async Task<Exercise?> GetByIdAsync(Guid exerciseUuid)
    {
        return await _exerciseRepository.GetActiveByIdAsync(exerciseUuid);
    }

    public async Task<Exercise> CreateAsync(Exercise exercise)
    {
        return await _exerciseRepository.CreateAsync(exercise);
    }

    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        return await _exerciseRepository.UpdateAsync(exercise);
    }

    public async Task SoftDeleteAsync(Guid exerciseUuid)
    {
        await _exerciseRepository.SoftDeleteAsync(exerciseUuid);
    }
}
