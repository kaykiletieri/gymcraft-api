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

        builder.HasData(
            new ExerciseCategory
            {
                Uuid = Guid.Parse("8e7a7403-faab-47a9-9d9d-491d0f7b65e2"),
                Name = "Peito",
                Description = "Exercícios de peito",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("0fe4d849-f885-478a-a771-85a872ebfa74"),
                Name = "Costas",
                Description = "Exercícios de costas",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("6d700f3e-3fb8-41a6-98cb-3753f10e9b95"),
                Name = "Pernas",
                Description = "Exercícios de pernas",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("68830480-1382-4fd3-a4d9-495345e52178"),
                Name = "Tríceps",
                Description = "Exercícios de tríceps",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("89b6489b-b657-4b19-89b0-60820d80592f"),
                Name = "Bíceps",
                Description = "Exercícios de bíceps",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("faeced17-7cc8-4a55-9dea-110e76e55018"),
                Name = "Deltóide",
                Description = "Exercícios de deltóide",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("0be52e17-4c21-4fb7-9f7e-18858973b926"),
                Name = "Trapézio",
                Description = "Exercícios de trapézio",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("88d501f6-b50b-4a52-a7d7-d950ef85debd"),
                Name = "Abdômen",
                Description = "Exercícios de abdômen",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ExerciseCategory
            {
                Uuid = Guid.Parse("940ceada-a91f-4328-a1e4-3ae47e9ee7a3"),
                Name = "Aeróbicos",
                Description = "Exercícios aeróbicos",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}
