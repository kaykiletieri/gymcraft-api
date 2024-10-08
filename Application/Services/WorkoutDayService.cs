using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;

namespace GymCraftAPI.Application.Services;

public class WorkoutDayService : IWorkoutDayService
{
    private readonly IWorkoutDayRepository _workoutDayRepository;

    public WorkoutDayService(IWorkoutDayRepository workoutDayRepository)
    {
        _workoutDayRepository = workoutDayRepository;
    }

    public async Task<IEnumerable<WorkoutDay>> GetAllAsync()
    {
        return await _workoutDayRepository.GetAllActiveAsync();
    }

    public async Task<WorkoutDay?> GetByIdAsync(Guid workoutDayUuid)
    {
        return await _workoutDayRepository.GetActiveByIdAsync(workoutDayUuid);
    }

    public async Task<WorkoutDay> CreateAsync(WorkoutDay workoutDay)
    {
        return await _workoutDayRepository.CreateAsync(workoutDay);
    }

    public async Task<WorkoutDay> UpdateAsync(WorkoutDay workoutDay)
    {
        return await _workoutDayRepository.UpdateAsync(workoutDay);
    }

    public async Task SoftDeleteAsync(Guid workoutDayUuid)
    {
        _ = await _workoutDayRepository.GetActiveByIdAsync(workoutDayUuid) ?? throw new KeyNotFoundException("Workout day not found");

        await _workoutDayRepository.SoftDeleteAsync(workoutDayUuid);
    }
}
