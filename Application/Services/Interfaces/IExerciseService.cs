using GymCraftAPI.Application.DTOs.Exercise;

namespace GymCraftAPI.Application.Services.Interfaces;

public interface IExerciseService
{
    Task<IEnumerable<ExerciseDTO>> GetAllAsync();
    Task<ExerciseDTO?> GetByIdAsync(Guid exerciseUuid);
    Task<ExerciseDTO> CreateAsync(CreateExerciseDTO exerciseDto);
    Task<ExerciseDTO> UpdateAsync(Guid exerciseUuid, UpdateExerciseDTO exerciseDto);
    Task SoftDeleteAsync(Guid exerciseUuid);
}
