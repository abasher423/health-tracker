using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingTableAuditToAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                schema: "health",
                table: "user_profile",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                schema: "health",
                table: "user_profile",
                newName: "Added");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                schema: "health",
                table: "progress",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                schema: "health",
                table: "progress",
                newName: "Added");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                schema: "health",
                table: "health_metric",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                schema: "health",
                table: "health_metric",
                newName: "Added");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                schema: "health",
                table: "health_data_entry",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                schema: "health",
                table: "health_data_entry",
                newName: "Added");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                schema: "health",
                table: "goal",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                schema: "health",
                table: "goal",
                newName: "Added");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modified",
                schema: "health",
                table: "user_profile",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Added",
                schema: "health",
                table: "user_profile",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Modified",
                schema: "health",
                table: "progress",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Added",
                schema: "health",
                table: "progress",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Modified",
                schema: "health",
                table: "health_metric",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Added",
                schema: "health",
                table: "health_metric",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Modified",
                schema: "health",
                table: "health_data_entry",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Added",
                schema: "health",
                table: "health_data_entry",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Modified",
                schema: "health",
                table: "goal",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "Added",
                schema: "health",
                table: "goal",
                newName: "CreatedAtUtc");
        }
    }
}
