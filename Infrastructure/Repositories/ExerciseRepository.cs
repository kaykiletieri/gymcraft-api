using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<Exercise> _repositoryBase;

    public ExerciseRepository(ApplicationDbContext context, IRepositoryBase<Exercise> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<Exercise>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<Exercise?> GetActiveByIdAsync(Guid exerciseUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(exerciseUuid);
    }

    public async Task<Exercise> CreateAsync(Exercise exercise)
    {
        return await _repositoryBase.CreateAsync(exercise);
    }

    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        return await _repositoryBase.UpdateAsync(exercise);
    }

    public async Task SoftDeleteAsync(Guid exerciseUuid)
    {
        await _repositoryBase.SoftDeleteAsync(exerciseUuid);
    }
}
