using GymCraftAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCraftAPI.Infrastructure.Mappings;

public class WorkoutDayMapping : IEntityTypeConfiguration<WorkoutDay>
{
    public void Configure(EntityTypeBuilder<WorkoutDay> builder)
    {
        builder.ToTable("workout_days");

        builder.HasKey(wd => wd.Uuid);

        builder.Property(wd => wd.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(wd => wd.WeekDay)
            .HasColumnName("day")
            .IsRequired();

        builder.Property(wd => wd.WorkoutUuid)
            .HasColumnName("workout_uuid")
            .IsRequired();

        builder.Property(wd => wd.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(wd => wd.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(wd => wd.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasOne(wd => wd.Workout)
            .WithMany(w => w.WorkoutDays)
            .HasForeignKey(wd => wd.WorkoutUuid);
    }
}
