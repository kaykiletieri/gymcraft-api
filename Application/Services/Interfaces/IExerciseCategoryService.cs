using GymCraftAPI.Application.DTOs;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IExerciseCategoryService
{
    Task<IEnumerable<ExerciseCategoryDTO>> GetAllAsync();
    Task<ExerciseCategoryDTO?> GetByIdAsync(Guid exerciseCategoryUuid);
    Task<ExerciseCategoryDTO> CreateAsync(CreateExerciseCategoryDTO exerciseCategoryDto);
    Task<ExerciseCategoryDTO> UpdateAsync(Guid exerciseCategoryUuid, UpdateExerciseCategoryDTO exerciseCategoryDto);
    Task SoftDeleteAsync(Guid exerciseCategoryUuid);
}
