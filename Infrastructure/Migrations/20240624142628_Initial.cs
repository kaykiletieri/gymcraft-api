using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymCraftAPI.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "exercise_categories",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_exercise_categories", x => x.uuid);
            });

        migrationBuilder.CreateTable(
            name: "users",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                email = table.Column<string>(type: "text", nullable: false),
                password_hash = table.Column<string>(type: "text", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_users", x => x.uuid);
            });

        migrationBuilder.CreateTable(
            name: "exercises",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                category_uuid = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_exercises", x => x.uuid);
                table.ForeignKey(
                    name: "FK_exercises_exercise_categories_category_uuid",
                    column: x => x.category_uuid,
                    principalTable: "exercise_categories",
                    principalColumn: "uuid",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "workouts",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_active = table.Column<bool>(type: "boolean", nullable: false),
                user_uuid = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_workouts", x => x.uuid);
                table.ForeignKey(
                    name: "FK_workouts_users_user_uuid",
                    column: x => x.user_uuid,
                    principalTable: "users",
                    principalColumn: "uuid",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "workout_days",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                day = table.Column<int>(type: "integer", nullable: false),
                workout_uuid = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_workout_days", x => x.uuid);
                table.ForeignKey(
                    name: "FK_workout_days_workouts_workout_uuid",
                    column: x => x.workout_uuid,
                    principalTable: "workouts",
                    principalColumn: "uuid",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "workout_exercises",
            columns: table => new
            {
                uuid = table.Column<Guid>(type: "uuid", nullable: false),
                exercise_uuid = table.Column<Guid>(type: "uuid", nullable: false),
                workout_day_uuid = table.Column<Guid>(type: "uuid", nullable: false),
                sets = table.Column<int>(type: "integer", nullable: false),
                repetitions = table.Column<int>(type: "integer", nullable: false),
                rest_time = table.Column<int>(type: "integer", nullable: true),
                notes = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_workout_exercises", x => x.uuid);
                table.ForeignKey(
                    name: "FK_workout_exercises_exercises_exercise_uuid",
                    column: x => x.exercise_uuid,
                    principalTable: "exercises",
                    principalColumn: "uuid",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_workout_exercises_workout_days_workout_day_uuid",
                    column: x => x.workout_day_uuid,
                    principalTable: "workout_days",
                    principalColumn: "uuid",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_exercises_category_uuid",
            table: "exercises",
            column: "category_uuid");

        migrationBuilder.CreateIndex(
            name: "IX_workout_days_workout_uuid",
            table: "workout_days",
            column: "workout_uuid");

        migrationBuilder.CreateIndex(
            name: "IX_workout_exercises_exercise_uuid",
            table: "workout_exercises",
            column: "exercise_uuid");

        migrationBuilder.CreateIndex(
            name: "IX_workout_exercises_workout_day_uuid",
            table: "workout_exercises",
            column: "workout_day_uuid");

        migrationBuilder.CreateIndex(
            name: "IX_workouts_user_uuid",
            table: "workouts",
            column: "user_uuid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "workout_exercises");

        migrationBuilder.DropTable(
            name: "exercises");

        migrationBuilder.DropTable(
            name: "workout_days");

        migrationBuilder.DropTable(
            name: "exercise_categories");

        migrationBuilder.DropTable(
            name: "workouts");

        migrationBuilder.DropTable(
            name: "users");
    }
}
