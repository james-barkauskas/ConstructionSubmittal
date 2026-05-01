using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionSubmittal_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProjectPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectNumber",
                table: "Projects",
                newName: "JobNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobNumber",
                table: "Projects",
                newName: "ProjectNumber");
        }
    }
}
