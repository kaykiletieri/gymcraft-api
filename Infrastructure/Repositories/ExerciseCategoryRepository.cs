using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;

namespace GymCraftAPI.Infrastructure.Repositories;

public class ExerciseCategoryRepository : IExerciseCategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IRepositoryBase<ExerciseCategory> _repositoryBase;

    public ExerciseCategoryRepository(ApplicationDbContext context, IRepositoryBase<ExerciseCategory> repositoryBase)
    {
        _context = context;
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<ExerciseCategory>> GetAllActiveAsync()
    {
        return await _repositoryBase.GetAllActiveAsync();
    }

    public async Task<ExerciseCategory?> GetActiveByIdAsync(Guid exerciseCategoryUuid)
    {
        return await _repositoryBase.GetActiveByIdAsync(exerciseCategoryUuid);
    }

    public async Task<ExerciseCategory> CreateAsync(ExerciseCategory exerciseCategory)
    {
        return await _repositoryBase.CreateAsync(exerciseCategory);
    }

    public async Task<ExerciseCategory> UpdateAsync(ExerciseCategory exerciseCategory)
    {
        return await _repositoryBase.UpdateAsync(exerciseCategory);
    }

    public async Task SoftDeleteAsync(Guid exerciseCategoryUuid)
    {
        await _repositoryBase.SoftDeleteAsync(exerciseCategoryUuid);
    }
}
