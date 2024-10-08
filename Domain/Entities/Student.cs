using GymCraftAPI.Domain.ValueObjects;

namespace GymCraftAPI.Domain.Entities;

public class Student : User
{
    public ICollection<Workout>? Workouts { get; private set; }

    public Student(Name name, Email email, string passwordHash) : base(name, email, passwordHash)
    {
        Workouts = [];
    }

    public void AssignWorkout(Workout workout)
    {
        if (workout == null)
        {
            throw new ArgumentException("Workout cannot be null.");
        }

        Workouts?.Add(workout);
    }

    public bool HasActiveWorkout(DateTime date)
    {
        foreach (Workout workout in Workouts!)
        {
            if (workout.IsActive && workout.WorkoutPeriod.IsActiveOn(date))
            {
                return true;
            }
        }
        return false;
    }

}
