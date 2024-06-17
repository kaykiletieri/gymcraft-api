using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class WorkoutExerciseRepository : IWorkoutExerciseRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<WorkoutExercise> _repositoryBase;

    public WorkoutExerciseRepository(ApplicationDbContext context, IRepositoryBase<WorkoutExercise> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<WorkoutExercise>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<WorkoutExercise?> GetActiveByIdAsync(Guid workoutExerciseUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(workoutExerciseUuid);
    }

    public async Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise)
    {
        return await _repositoryBase.CreateAsync(workoutExercise);
    }

    public async Task<WorkoutExercise> UpdateAsync(WorkoutExercise workoutExercise)
    {
        return await _repositoryBase.UpdateAsync(workoutExercise);
    }

    public async Task SoftDeleteAsync(Guid workoutExerciseUuid)
    {
        await _repositoryBase.SoftDeleteAsync(workoutExerciseUuid);
    }
}
