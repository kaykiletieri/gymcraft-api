using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Domain.Interfaces;

public interface IWorkoutExerciseRepository
{
    Task<IEnumerable<WorkoutExercise>> GetAllActiveAsync();
    Task<WorkoutExercise?> GetActiveByIdAsync(Guid workoutExerciseUuid);
    Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise);
    Task<WorkoutExercise> UpdateAsync(WorkoutExercise workoutExercise);
    Task SoftDeleteAsync(Guid workoutExerciseUuid);
}
