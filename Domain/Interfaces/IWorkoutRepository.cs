using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Domain.Interfaces;

public interface IWorkoutRepository
{
    Task<IEnumerable<Workout>> GetAllActiveAsync();
    Task<Workout?> GetActiveByIdAsync(Guid workoutUuid);
    Task<Workout> CreateAsync(Workout workout);
    Task<Workout> UpdateAsync(Workout workout);
    Task SoftDeleteAsync(Guid workoutUuid);
}
