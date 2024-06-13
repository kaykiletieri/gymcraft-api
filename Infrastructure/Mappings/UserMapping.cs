using GymCraftAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCraftAPI.Infrastructure.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Uuid);

        builder.Property(u => u.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(u => u.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(u => u.DeletedAt)
            .HasColumnName("deleted_at");

        builder.HasMany(u => u.Workouts)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserUuid);
    }
}
