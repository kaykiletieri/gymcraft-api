using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;

namespace GymCraftAPI.Application.Services;

public class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _workoutExerciseRepository;

    public WorkoutExerciseService(IWorkoutExerciseRepository workoutExerciseRepository)
    {
        _workoutExerciseRepository = workoutExerciseRepository;
    }

    public async Task<IEnumerable<WorkoutExercise>> GetAllAsync()
    {
        return await _workoutExerciseRepository.GetAllActiveAsync();
    }

    public async Task<WorkoutExercise?> GetByIdAsync(Guid workoutExerciseUuid)
    {
        return await _workoutExerciseRepository.GetActiveByIdAsync(workoutExerciseUuid);
    }

    public async Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise)
    {
        return await _workoutExerciseRepository.CreateAsync(workoutExercise);
    }

    public async Task<WorkoutExercise> UpdateAsync(WorkoutExercise workoutExercise)
    {
        return await _workoutExerciseRepository.UpdateAsync(workoutExercise);
    }

    public async Task SoftDeleteAsync(Guid workoutExerciseUuid)
    {
        _ = await _workoutExerciseRepository.GetActiveByIdAsync(workoutExerciseUuid) ?? throw new KeyNotFoundException("Workout exercise not found");

        await _workoutExerciseRepository.SoftDeleteAsync(workoutExerciseUuid);
    }
}
