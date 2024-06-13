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
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutDay> WorkoutDays { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:HistoryTableName", "migrations_history");

        modelBuilder.ApplyConfiguration(new ExerciseMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new WorkoutMapping());
        modelBuilder.ApplyConfiguration(new WorkoutDayMapping());

        base.OnModelCreating(modelBuilder);
    }
}
