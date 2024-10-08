using GymCraftAPI.Domain.Enums;

namespace GymCraftAPI.Domain.Entities;

public class WorkoutDay : EntityBase
{
    public WeekDay WeekDay { get; private set; }
    public Guid WorkoutUuid { get; private set; }
    public Workout? Workout { get; private set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; private set; }

    public WorkoutDay(WeekDay weekDay, Guid workoutUuid)
    {
        WeekDay = weekDay;
        WorkoutUuid = workoutUuid;
        WorkoutExercises = [];
    }

    public IEnumerable<WorkoutExercise> GetExercises()
    {
        return WorkoutExercises;
    }

    public void AddExercise(WorkoutExercise workoutExercise)
    {
        if (workoutExercise == null)
        {
            throw new ArgumentException("WorkoutExercise cannot be null.");
        }

        WorkoutExercises.Add(workoutExercise);
        UpdateTimestamps();
    }

    public void UpdateExercise(WorkoutExercise updatedWorkoutExercise)
    {
        WorkoutExercise? workoutExercise = WorkoutExercises.FirstOrDefault(e => e.Uuid == updatedWorkoutExercise.Uuid);
        if (workoutExercise != null)
        {
            workoutExercise.UpdateDetails(updatedWorkoutExercise.Sets, updatedWorkoutExercise.Repetitions, updatedWorkoutExercise.RestTime, updatedWorkoutExercise.Weight);
            UpdateTimestamps();
        }
        else
        {
            throw new ArgumentException("WorkoutExercise not found.");
        }
    }

    public void RemoveExercise(WorkoutExercise workoutExercise)
    {
        WorkoutExercise? exerciseToRemove = WorkoutExercises.FirstOrDefault(we => we.Uuid == workoutExercise.Uuid);

        if (exerciseToRemove != null)
        {
            WorkoutExercises.Remove(exerciseToRemove);
            UpdateTimestamps();
        }
        else
        {
            throw new ArgumentException("WorkoutExercise not found.");
        }
    }

    public void CompleteExercise(Guid workoutExerciseUuid)
    {
        WorkoutExercise? workoutExercise = WorkoutExercises.FirstOrDefault(e => e.Uuid == workoutExerciseUuid);
        if (workoutExercise != null)
        {
            workoutExercise.SetCompletionStatus(true);
            UpdateTimestamps();
        }
        else
        {
            throw new ArgumentException("WorkoutExercise not found.");
        }
    }
}
