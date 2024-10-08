using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Domain.Interfaces;

public interface IWorkoutDayRepository
{
    Task<IEnumerable<WorkoutDay>> GetAllActiveAsync();
    Task<WorkoutDay?> GetActiveByIdAsync(Guid workoutDayUuid);
    Task<WorkoutDay> CreateAsync(WorkoutDay workoutDay);
    Task<WorkoutDay> UpdateAsync(WorkoutDay workoutDay);
    Task SoftDeleteAsync(Guid workoutDayUuid);
}
