using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<Workout>> GetAllAsync()
    {
        return await _workoutRepository.GetAllActiveAsync();
    }

    public async Task<Workout?> GetByIdAsync(Guid workoutUuid)
    {
        return await _workoutRepository.GetActiveByIdAsync(workoutUuid);
    }

    public async Task<Workout> CreateAsync(Workout workout)
    {
        return await _workoutRepository.CreateAsync(workout);
    }

    public async Task<Workout> UpdateAsync(Workout workout)
    {
        return await _workoutRepository.UpdateAsync(workout);
    }

    public async Task SoftDeleteAsync(Guid workoutUuid)
    {
        await _workoutRepository.SoftDeleteAsync(workoutUuid);
    }
}
