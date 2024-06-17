using GymCraftAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCraftAPI.Infrastructure.Mappings;

public class WorkoutExerciseMapping : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.ToTable("workout_exercises");

        builder.HasKey(we => we.Uuid);

        builder.Property(we => we.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(we => we.WorkoutDayUuid)
            .HasColumnName("workout_day_uuid")
            .IsRequired();

        builder.Property(we => we.ExerciseUuid)
            .HasColumnName("exercise_uuid")
            .IsRequired();

        builder.Property(we => we.Sets)
            .HasColumnName("sets")
            .IsRequired();

        builder.Property(we => we.Repetitions)
            .HasColumnName("repetitions")
            .IsRequired();

        builder.Property(we => we.RestTime)
            .HasColumnName("rest_time");

        builder.Property(we => we.Notes)
            .HasColumnName("notes");

        builder.Property(we => we.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(we => we.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(we => we.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(we => we.WorkoutDay)
            .WithMany(wd => wd.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutDayUuid);

        builder.HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseUuid);
    }
}
