using GymCraftAPI.Application.DTOs.ExerciseCategory;
using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Mappers.Interfaces;

public interface IExerciseCategoryMapper
{
    ExerciseCategory MapToEntity(CreateExerciseCategoryDTO exerciseCategoryDto);
    ExerciseCategoryDTO MapToDto(ExerciseCategory exerciseCategory);
    IEnumerable<ExerciseCategoryDTO> MapToDto(IEnumerable<ExerciseCategory> exerciseCategories);
}
