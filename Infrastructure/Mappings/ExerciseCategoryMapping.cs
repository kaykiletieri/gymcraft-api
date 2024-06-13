using GymCraftAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCraftAPI.Infrastructure.Mappings;

public class ExerciseCategoryMapping : IEntityTypeConfiguration<ExerciseCategory>
{
    public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
    {
        builder.ToTable("exercise_categories");

        builder.HasKey(e => e.Uuid);

        builder.Property(e => e.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(e => e.Description)
            .HasColumnName("description");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasMany(e => e.Exercises)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryUuid);
    }
}
