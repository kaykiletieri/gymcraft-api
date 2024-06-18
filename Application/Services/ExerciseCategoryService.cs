
using GymCraftAPI.Application.DTOs;
using GymCraftAPI.Application.Helpers;
using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;
using GymCraftAPI.Infrastructure.Repositories.Interfaces;

namespace GymCraftAPI.Application.Services;

public class ExerciseCategoryService : IExerciseCategoryService
{
    private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
    private readonly IExerciseCategoryMapper _exerciseCategoryMapper;
    private readonly IPropertyUpdater _propertyUpdater;

    public ExerciseCategoryService(IExerciseCategoryRepository exerciseCategoryRepository, IExerciseCategoryMapper exerciseCategoryMapper, IPropertyUpdater propertyUpdater)
    {
        _exerciseCategoryRepository = exerciseCategoryRepository;
        _exerciseCategoryMapper = exerciseCategoryMapper;
        _propertyUpdater = propertyUpdater;
    }

    public async Task<IEnumerable<ExerciseCategoryDTO>> GetAllAsync()
    {
        IEnumerable<ExerciseCategory> exerciseCategories = await _exerciseCategoryRepository.GetAllActiveAsync();

        return _exerciseCategoryMapper.MapToDto(exerciseCategories);
    }

    public async Task<ExerciseCategoryDTO?> GetByIdAsync(Guid exerciseCategoryUuid)
    {
        ExerciseCategory? exerciseCategory = await _exerciseCategoryRepository.GetActiveByIdAsync(exerciseCategoryUuid);

        return exerciseCategory != null ? _exerciseCategoryMapper.MapToDto(exerciseCategory) : null;
    }

    public async Task<ExerciseCategoryDTO> CreateAsync(CreateExerciseCategoryDTO exerciseCategoryDto)
    {
        ExerciseCategory exerciseCategory = _exerciseCategoryMapper.MapToEntity(exerciseCategoryDto);

        ExerciseCategory createdExerciseCategory = await _exerciseCategoryRepository.CreateAsync(exerciseCategory);

        return _exerciseCategoryMapper.MapToDto(createdExerciseCategory);
    }

    public async Task<ExerciseCategoryDTO> UpdateAsync(Guid exerciseCategoryUuid, UpdateExerciseCategoryDTO exerciseCategoryDto)
    {
        ExerciseCategory? exerciseCategory = await _exerciseCategoryRepository.GetActiveByIdAsync(exerciseCategoryUuid) ?? throw new KeyNotFoundException("Exercise category not found");

        _propertyUpdater.UpdatePropertyIfNotEmpty(value => exerciseCategory.Name = value, exerciseCategoryDto.Name);
        _propertyUpdater.UpdatePropertyIfNotEmpty(value => exerciseCategory.Description = value, exerciseCategoryDto.Description);

        exerciseCategory.UpdatedAt = DateTime.UtcNow;

        ExerciseCategory updatedExerciseCategory = await _exerciseCategoryRepository.UpdateAsync(exerciseCategory);

        return _exerciseCategoryMapper.MapToDto(updatedExerciseCategory);
    }

    public async Task SoftDeleteAsync(Guid exerciseCategoryUuid)
    {
        await _exerciseCategoryRepository.SoftDeleteAsync(exerciseCategoryUuid);
    }
}
