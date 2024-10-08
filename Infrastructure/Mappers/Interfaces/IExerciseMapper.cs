using GymCraftAPI.Application.DTOs.Exercise;
using GymCraftAPI.Domain.Entities;

namespace GymCraftAPI.Infrastructure.Mappers.Interfaces;

public interface IExerciseMapper
{

    Exercise MapToEntity(CreateExerciseDTO exerciseDto);
    ExerciseDTO MapToDTO(Exercise exercise);
    IEnumerable<ExerciseDTO> MapToDTO(IEnumerable<Exercise> exercises);
}
