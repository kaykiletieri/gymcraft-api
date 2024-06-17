using GymCraftAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCraftAPI.Infrastructure.Mappings;

public class WorkoutMapping : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("workouts");

        builder.HasKey(w => w.Uuid);

        builder.Property(w => w.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(w => w.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(w => w.Description)
            .HasColumnName("description");

        builder.Property(w => w.StartDate)
            .HasColumnName("start_date");

        builder.Property(w => w.EndDate)
            .HasColumnName("end_date");

        builder.Property(w => w.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(w => w.UserUuid)
            .HasColumnName("user_uuid")
            .IsRequired();

        builder.Property(w => w.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(w => w.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(w => w.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasMany(w => w.WorkoutDays)
            .WithOne(wd => wd.Workout)
            .HasForeignKey(wd => wd.WorkoutUuid);

        builder.HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserUuid);
    }
}
