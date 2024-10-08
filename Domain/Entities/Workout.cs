using GymCraftAPI.Domain.Enums;
using GymCraftAPI.Domain.ValueObjects;

namespace GymCraftAPI.Domain.Entities;

public class Workout : EntityBase
{
    public Name Name { get; private set; }
    public string? Description { get; private set; }
    public WorkoutPeriod WorkoutPeriod { get; private set; }
    public bool IsActive { get; private set; }
    public Guid StudentUuid { get; private set; }
    public Student? Student { get; private set; }
    public ICollection<WorkoutDay> WorkoutDays { get; private set; }

    public Workout(Name name, Guid studentUuid, WorkoutPeriod workoutPeriod, string? description = null)
    {
        Name = name;
        StudentUuid = studentUuid;
        Description = description;
        WorkoutPeriod = workoutPeriod;
        IsActive = true;
        WorkoutDays = [];
    }

    public void AddWorkoutDay(WorkoutDay workoutDay)
    {
        if (workoutDay == null)
        {
            throw new ArgumentException("WorkoutDay cannot be null.");
        }

        if (workoutDay.WeekDay < WeekDay.Monday || workoutDay.WeekDay > WeekDay.Saturday)
        {
            throw new ArgumentException("WorkoutDay must be a valid week day.");
        }

        WorkoutDays.Add(workoutDay);
        UpdateTimestamps();
    }

    public void SetDates(DateTime startDate, DateTime? endDate)
    {
        WorkoutPeriod = new WorkoutPeriod(startDate, endDate);
        UpdateTimestamps();
    }

    public IEnumerable<DateTime> GetTrainingDays()
    {
        if (WorkoutDays.Count == 0)
        {
            throw new InvalidOperationException("No WorkoutDays associated with this workout.");
        }

        List<DateTime> trainingDays = [];

        foreach (DateTime day in WorkoutPeriod.GetAllDays())
        {
            if (WorkoutDays.Any(wd => wd.WeekDay == (WeekDay)day.DayOfWeek))
            {
                trainingDays.Add(day);
            }
        }

        return trainingDays;
    }
}
