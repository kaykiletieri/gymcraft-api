using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymCraftAPI.Migrations;

/// <inheritdoc />
public partial class AddDefaultExerciseCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "exercise_categories",
            columns: new[] { "uuid", "created_at", "deleted_at", "description", "name", "updated_at" },
            values: new object[,]
            {
                { new Guid("0be52e17-4c21-4fb7-9f7e-18858973b926"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1467), null, "Exercícios de trapézio", "Trapézio", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1467) },
                { new Guid("0fe4d849-f885-478a-a771-85a872ebfa74"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1456), null, "Exercícios de costas", "Costas", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1457) },
                { new Guid("68830480-1382-4fd3-a4d9-495345e52178"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1460), null, "Exercícios de tríceps", "Tríceps", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1460) },
                { new Guid("6d700f3e-3fb8-41a6-98cb-3753f10e9b95"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1458), null, "Exercícios de pernas", "Pernas", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1458) },
                { new Guid("88d501f6-b50b-4a52-a7d7-d950ef85debd"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1468), null, "Exercícios de abdômen", "Abdômen", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1468) },
                { new Guid("89b6489b-b657-4b19-89b0-60820d80592f"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1462), null, "Exercícios de bíceps", "Bíceps", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1462) },
                { new Guid("8e7a7403-faab-47a9-9d9d-491d0f7b65e2"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1453), null, "Exercícios de peito", "Peito", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1454) },
                { new Guid("940ceada-a91f-4328-a1e4-3ae47e9ee7a3"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1470), null, "Exercícios aeróbicos", "Aeróbicos", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1470) },
                { new Guid("faeced17-7cc8-4a55-9dea-110e76e55018"), new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1465), null, "Exercícios de deltóide", "Deltóide", new DateTime(2024, 6, 24, 14, 42, 1, 558, DateTimeKind.Utc).AddTicks(1465) }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("0be52e17-4c21-4fb7-9f7e-18858973b926"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("0fe4d849-f885-478a-a771-85a872ebfa74"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("68830480-1382-4fd3-a4d9-495345e52178"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("6d700f3e-3fb8-41a6-98cb-3753f10e9b95"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("88d501f6-b50b-4a52-a7d7-d950ef85debd"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("89b6489b-b657-4b19-89b0-60820d80592f"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("8e7a7403-faab-47a9-9d9d-491d0f7b65e2"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("940ceada-a91f-4328-a1e4-3ae47e9ee7a3"));

        migrationBuilder.DeleteData(
            table: "exercise_categories",
            keyColumn: "uuid",
            keyValue: new Guid("faeced17-7cc8-4a55-9dea-110e76e55018"));
    }
}
