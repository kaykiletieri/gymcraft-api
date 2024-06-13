using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<Workout> _repositoryBase;

    public WorkoutRepository(ApplicationDbContext context, IRepositoryBase<Workout> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<Workout>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<Workout?> GetActiveByIdAsync(Guid workoutUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(workoutUuid);
    }

    public async Task<Workout> CreateAsync(Workout workout)
    {
        return await _repositoryBase.CreateAsync(workout);
    }

    public async Task<Workout> UpdateAsync(Workout workout)
    {
        return await _repositoryBase.UpdateAsync(workout);
    }

    public async Task SoftDeleteAsync(Guid workoutUuid)
    {
        await _repositoryBase.SoftDeleteAsync(workoutUuid);
    }
}
