using GymCraftAPI.Domain.ValueObjects;

namespace GymCraftAPI.Domain.Entities;

public class Instructor : User
{
    public ICollection<Workout>? CreatedWorkouts { get; private set; }

    public Instructor(Name name, Email email, string passwordHash) : base(name, email, passwordHash)
    {
        CreatedWorkouts = [];
    }

    public Workout CreateWorkoutForStudent(Name workoutName, Student student, WorkoutPeriod workoutPeriod, string? description = null)
    {
        if (student == null)
        {
            throw new ArgumentException("Student cannot be null.");
        }

        Workout workout = new(workoutName, student.Uuid, workoutPeriod, description);

        CreatedWorkouts?.Add(workout);
        student.AssignWorkout(workout);
        return workout;
    }

}
