using GymCraftAPI.Domain.Enums;

namespace GymCraftAPI.Domain.Entities;

public class Exercise : EntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ExerciseCategory Category { get; set; }
}
