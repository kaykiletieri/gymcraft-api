using GymCraftAPI.Application.DTOs.Exercise;
using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;

namespace GymCraftAPI.Infrastructure.Mappers;

public class ExerciseMapper : IExerciseMapper
{
    public Exercise MapToEntity(CreateExerciseDTO exerciseDto)
    {
        return new Exercise
        {
            Uuid = Guid.NewGuid(),
            Name = exerciseDto.Name,
            Description = exerciseDto.Description,
            CategoryUuid = exerciseDto.CategoryUuid,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    public ExerciseDTO MapToDTO(Exercise exercise)
    {
        return new ExerciseDTO
        {
            Uuid = exercise.Uuid,
            Name = exercise.Name,
            Description = exercise.Description,
            CategoryUuid = exercise.CategoryUuid,
            CreatedAt = exercise.CreatedAt,
            UpdatedAt = exercise.UpdatedAt
        };
    }

    public IEnumerable<ExerciseDTO> MapToDTO(IEnumerable<Exercise> exercises)
    {
        return exercises.Select(MapToDTO);
    }
}
