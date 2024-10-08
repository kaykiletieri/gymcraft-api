namespace GymCraftAPI.Domain.Entities;

public class WorkoutExercise : EntityBase
{
    public Guid ExerciseUuid { get; private set; }
    public Exercise? Exercise { get; private set; }
    public Guid WorkoutDayUuid { get; private set; }
    public WorkoutDay? WorkoutDay { get; private set; }
    public int Sets { get; private set; }
    public int Repetitions { get; private set; }
    public int? RestTime { get; private set; }
    public int? Weight { get; private set; }
    public bool IsCompleted { get; private set; }

    public WorkoutExercise(Guid exerciseUuid, Guid workoutDayUuid, int sets, int repetitions, int? restTime = null, int? weight = null)
    {
        if (sets <= 0)
        {
            throw new ArgumentException("Sets must be greater than 0.");
        }

        if (repetitions <= 0)
        {
            throw new ArgumentException("Repetitions must be greater than 0.");
        }

        if (exerciseUuid == Guid.Empty || workoutDayUuid == Guid.Empty)
        {
            throw new ArgumentException("UUIDs cannot be empty.");
        }

        ExerciseUuid = exerciseUuid;
        WorkoutDayUuid = workoutDayUuid;
        Sets = sets;
        Repetitions = repetitions;
        RestTime = restTime;
        Weight = weight;
        IsCompleted = false;
    }
    public void UpdateDetails(int sets, int repetitions, int? restTime, int? weight)
    {
        Sets = sets;
        Repetitions = repetitions;
        RestTime = restTime;
        Weight = weight;
        UpdateTimestamps();
    }

    public void SetCompletionStatus(bool isCompleted)
    {
        IsCompleted = isCompleted;
        UpdateTimestamps();
    }

    public void UpdateSets(int sets)
    {
        if (sets <= 0)
        {
            throw new ArgumentException("Sets must be greater than 0.");
        }

        Sets = sets;
        UpdateTimestamps();
    }

    public void UpdateRepetitions(int repetitions)
    {
        if (repetitions <= 0)
        {
            throw new ArgumentException("Repetitions must be greater than 0.");
        }

        Repetitions = repetitions;
        UpdateTimestamps();
    }

    public void UpdateRestTime(int? restTime)
    {
        RestTime = restTime;
        UpdateTimestamps();
    }

    public void UpdateWeight(int? weight)
    {
        Weight = weight;
        UpdateTimestamps();
    }
}
