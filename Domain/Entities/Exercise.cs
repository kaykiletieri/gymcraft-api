using GymCraftAPI.Domain.ValueObjects;

namespace GymCraftAPI.Domain.Entities;

public class Exercise : EntityBase
{
    public Name Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryUuid { get; set; }
    public ExerciseCategory? Category { get; set; }
    public ICollection<WorkoutExercise>? WorkoutExercises { get; set; }

    public Exercise(Name name, Guid categoryuuid, string? description = null)
    {
        Name = name;
        CategoryUuid = categoryuuid;
        Description = description;
        WorkoutExercises = [];
    }

    public void AssignCategory(ExerciseCategory category)
    {
        Category = category ?? throw new ArgumentException("Category cannot be null.");
        CategoryUuid = category.Uuid;
        UpdateTimestamps();
    }
}
