using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IWorkoutExerciseService
{
    Task<IEnumerable<WorkoutExercise>> GetAllAsync();
    Task<WorkoutExercise?> GetByIdAsync(Guid workoutExerciseUuid);
    Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise);
    Task<WorkoutExercise> UpdateAsync(WorkoutExercise workoutExercise);
    Task SoftDeleteAsync(Guid workoutExerciseUuid);
}
