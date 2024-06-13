using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IWorkoutDayService
{
    Task<IEnumerable<WorkoutDay>> GetAllAsync();
    Task<WorkoutDay?> GetByIdAsync(Guid workoutDayUuid);
    Task<WorkoutDay> CreateAsync(WorkoutDay workoutDay);
    Task<WorkoutDay> UpdateAsync(WorkoutDay workoutDay);
    Task SoftDeleteAsync(Guid workoutDayUuid);
}
