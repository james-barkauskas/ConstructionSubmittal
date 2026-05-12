using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionSubmittal_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSubmittalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Submittals",
                columns: new[] { "Id", "ProjectId", "SpecSection", "Status", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, null, 0, "Interior Lighting : Product Data", 0 },
                    { 2, 1, null, 0, "Exterior Lighting : Product Data", 0 },
                    { 3, 1, null, 0, "Interior Lighting : Shop Drawing", 2 },
                    { 4, 2, null, 0, "Steel Framing : Shop Drawing", 2 },
                    { 5, 2, null, 0, "Steel Framing : Product Data", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Submittals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Submittals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Submittals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Submittals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Submittals",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
