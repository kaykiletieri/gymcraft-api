using GymCraftAPI.Domain.Enums;

namespace GymCraftAPI.Domain.Entities;

public class WorkoutDay : EntityBase
{
    public required WeekDay WeekDay { get; set; }
    public required Guid WorkoutUuid { get; set; }
    public Workout? Workout { get; set; }
    public ICollection<WorkoutExercise>? WorkoutExercises { get; set; }
}
