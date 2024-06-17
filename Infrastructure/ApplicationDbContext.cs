using GymCraftAPI.Domain.Entities;
using GymCraftAPI.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GymCraftAPI.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutDay> WorkoutDays { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExerciseMapping());
        modelBuilder.ApplyConfiguration(new ExerciseCategoryMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new WorkoutMapping());
        modelBuilder.ApplyConfiguration(new WorkoutDayMapping());
        modelBuilder.ApplyConfiguration(new WorkoutExerciseMapping());

        base.OnModelCreating(modelBuilder);
    }
}
