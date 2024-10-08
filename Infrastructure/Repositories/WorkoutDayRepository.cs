using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class WorkoutDayRepository : IWorkoutDayRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<WorkoutDay> _repositoryBase;

    public WorkoutDayRepository(ApplicationDbContext context, IRepositoryBase<WorkoutDay> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<WorkoutDay>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<WorkoutDay?> GetActiveByIdAsync(Guid workoutDayUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(workoutDayUuid);
    }

    public async Task<WorkoutDay> CreateAsync(WorkoutDay workoutDay)
    {
        return await _repositoryBase.CreateAsync(workoutDay);
    }

    public async Task<WorkoutDay> UpdateAsync(WorkoutDay workoutDay)
    {
        return await _repositoryBase.UpdateAsync(workoutDay);
    }

    public async Task SoftDeleteAsync(Guid workoutDayUuid)
    {
        await _repositoryBase.SoftDeleteAsync(workoutDayUuid);
    }
}
