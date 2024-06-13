using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IWorkoutService
{
    Task<IEnumerable<Workout>> GetAllAsync();
    Task<Workout?> GetByIdAsync(Guid workoutUuid);
    Task<Workout> CreateAsync(Workout workout);
    Task<Workout> UpdateAsync(Workout workout);
    Task SoftDeleteAsync(Guid workoutUuid);
}
