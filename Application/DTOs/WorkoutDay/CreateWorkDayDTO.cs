using GymCraftAPI.Domain.Enums;

namespace GymCraftAPI.Application.DTOs.WorkoutDay;

public record CreateWorkdayDTO
{
    public Guid? WorkoutUuid { get; init; }
    public WeekDay? WeekDay { get; init; }

}
