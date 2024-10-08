using GymCraftAPI.Application.DTOs.Exercise;
using GymCraftAPI.Application.Helpers.Interfaces;
using GymCraftAPI.Application.Services.Interfaces;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Domain.Interfaces;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;

namespace GymCraftAPI.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
    private readonly IExerciseMapper _exerciseMapper;
    private readonly IPropertyUpdater _propertyUpdater;

    public ExerciseService(IExerciseRepository exerciseRepository,
        IExerciseCategoryRepository exerciseCategoryRepository,
        IExerciseMapper exerciseMapper,
        IPropertyUpdater propertyUpdater)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseCategoryRepository = exerciseCategoryRepository;
        _exerciseMapper = exerciseMapper;
        _propertyUpdater = propertyUpdater;
    }

    public async Task<IEnumerable<ExerciseDTO>> GetAllAsync()
    {
        IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllActiveAsync();

        return _exerciseMapper.MapToDTO(exercises);
    }

    public async Task<ExerciseDTO?> GetByIdAsync(Guid exerciseUuid)
    {
        Exercise? exercise = await _exerciseRepository.GetActiveByIdAsync(exerciseUuid);

        return exercise != null ? _exerciseMapper.MapToDTO(exercise) : null;
    }

    public async Task<ExerciseDTO> CreateAsync(CreateExerciseDTO exerciseDto)
    {
        _ = await _exerciseCategoryRepository.GetActiveByIdAsync(exerciseDto.CategoryUuid) ?? throw new KeyNotFoundException("Category not found");

        Exercise exercise = _exerciseMapper.MapToEntity(exerciseDto);

        Exercise createdExercise = await _exerciseRepository.CreateAsync(exercise);

        return _exerciseMapper.MapToDTO(createdExercise);
    }

    public async Task<ExerciseDTO> UpdateAsync(Guid exerciseUuid, UpdateExerciseDTO exerciseDto)
    {
        Exercise? exercise = await _exerciseRepository.GetActiveByIdAsync(exerciseUuid) ?? throw new KeyNotFoundException("Exercise not found");

        if (exerciseDto.CategoryUuid.HasValue)
        {
            _ = await _exerciseCategoryRepository.GetActiveByIdAsync(exerciseDto.CategoryUuid.Value) ?? throw new KeyNotFoundException("Category not found");

            exercise.CategoryUuid = exerciseDto.CategoryUuid.Value;
        }
        _propertyUpdater.UpdatePropertyIfNotEmpty(value => exercise.Name = value, exerciseDto.Name);
        _propertyUpdater.UpdatePropertyIfNotEmpty(value => exercise.Description = value, exerciseDto.Description);

        exercise.UpdatedAt = DateTime.UtcNow;

        Exercise updatedExercise = await _exerciseRepository.UpdateAsync(exercise);

        return _exerciseMapper.MapToDTO(updatedExercise);
    }

    public async Task SoftDeleteAsync(Guid exerciseUuid)
    {
        _ = await _exerciseRepository.GetActiveByIdAsync(exerciseUuid) ?? throw new KeyNotFoundException("Exercise not found");

        await _exerciseRepository.SoftDeleteAsync(exerciseUuid);
    }
}
