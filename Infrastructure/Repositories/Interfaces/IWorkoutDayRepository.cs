using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Repositories.Interfaces;

public interface IWorkoutDayRepository
{
    Task<IEnumerable<WorkoutDay>> GetAllActiveAsync();
    Task<WorkoutDay?> GetActiveByIdAsync(Guid workoutDayUuid);
    Task<WorkoutDay> CreateAsync(WorkoutDay workoutDay);
    Task<WorkoutDay> UpdateAsync(WorkoutDay workoutDay);
    Task SoftDeleteAsync(Guid workoutDayUuid);
}
