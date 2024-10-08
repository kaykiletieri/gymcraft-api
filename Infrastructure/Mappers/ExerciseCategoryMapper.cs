using GymCraftAPI.Application.DTOs.ExerciseCategory;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;

namespace GymCraftAPI.Infrastructure.Mappers;

public class ExerciseCategoryMapper : IExerciseCategoryMapper
{
    public ExerciseCategory MapToEntity(CreateExerciseCategoryDTO exerciseCategoryDto)
    {
        return new ExerciseCategory
        {
            Uuid = Guid.NewGuid(),
            Name = exerciseCategoryDto.Name,
            Description = exerciseCategoryDto.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    public ExerciseCategoryDTO MapToDto(ExerciseCategory exerciseCategory)
    {
        return new ExerciseCategoryDTO
        {
            Uuid = exerciseCategory.Uuid,
            CategoryName = exerciseCategory.Name,
            Description = exerciseCategory.Description,
            CreatedAt = exerciseCategory.CreatedAt,
            UpdatedAt = exerciseCategory.UpdatedAt,
        };
    }

    public IEnumerable<ExerciseCategoryDTO> MapToDto(IEnumerable<ExerciseCategory> exerciseCategories)
    {
        return exerciseCategories.Select(MapToDto);
    }
}
