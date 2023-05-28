using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserEntityAndConfiguringEntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goal_health_data_entry_HealthDataEntryId",
                schema: "health",
                table: "goal");

            migrationBuilder.DropForeignKey(
                name: "FK_health_data_entry_health_metric_HealthMetricId",
                schema: "health",
                table: "health_data_entry");

            migrationBuilder.DropForeignKey(
                name: "FK_health_metric_user_profile_UserProfileId",
                schema: "health",
                table: "health_metric");

            migrationBuilder.DropForeignKey(
                name: "FK_progress_goal_GoalId",
                schema: "health",
                table: "progress");

            migrationBuilder.DropIndex(
                name: "IX_health_metric_UserProfileId",
                schema: "health",
                table: "health_metric");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                schema: "health",
                table: "health_metric");

            migrationBuilder.RenameColumn(
                name: "HealthDataEntryId",
                schema: "health",
                table: "goal",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_goal_HealthDataEntryId",
                schema: "health",
                table: "goal",
                newName: "IX_goal_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "health",
                table: "user_profile",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "health",
                table: "progress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "health",
                table: "health_data_entry",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "user",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    Added = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_id", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_profile_UserId",
                schema: "health",
                table: "user_profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_progress_UserId",
                schema: "health",
                table: "progress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_health_data_entry_UserId",
                schema: "health",
                table: "health_data_entry",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "goal",
                column: "UserId",
                principalSchema: "health",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_health_metric_id",
                schema: "health",
                table: "health_data_entry",
                column: "HealthMetricId",
                principalSchema: "health",
                principalTable: "health_metric",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "health_data_entry",
                column: "UserId",
                principalSchema: "health",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_id",
                schema: "health",
                table: "progress",
                column: "GoalId",
                principalSchema: "health",
                principalTable: "goal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "progress",
                column: "UserId",
                principalSchema: "health",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "user_profile",
                column: "UserId",
                principalSchema: "health",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "goal");

            migrationBuilder.DropForeignKey(
                name: "fk_health_metric_id",
                schema: "health",
                table: "health_data_entry");

            migrationBuilder.DropForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "health_data_entry");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_id",
                schema: "health",
                table: "progress");

            migrationBuilder.DropForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "progress");

            migrationBuilder.DropForeignKey(
                name: "fk_user_id",
                schema: "health",
                table: "user_profile");

            migrationBuilder.DropTable(
                name: "user",
                schema: "health");

            migrationBuilder.DropIndex(
                name: "IX_user_profile_UserId",
                schema: "health",
                table: "user_profile");

            migrationBuilder.DropIndex(
                name: "IX_progress_UserId",
                schema: "health",
                table: "progress");

            migrationBuilder.DropIndex(
                name: "IX_health_data_entry_UserId",
                schema: "health",
                table: "health_data_entry");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "health",
                table: "user_profile");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "health",
                table: "progress");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "health",
                table: "health_data_entry");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "health",
                table: "goal",
                newName: "HealthDataEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_goal_UserId",
                schema: "health",
                table: "goal",
                newName: "IX_goal_HealthDataEntryId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                schema: "health",
                table: "health_metric",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_health_metric_UserProfileId",
                schema: "health",
                table: "health_metric",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_goal_health_data_entry_HealthDataEntryId",
                schema: "health",
                table: "goal",
                column: "HealthDataEntryId",
                principalSchema: "health",
                principalTable: "health_data_entry",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_health_data_entry_health_metric_HealthMetricId",
                schema: "health",
                table: "health_data_entry",
                column: "HealthMetricId",
                principalSchema: "health",
                principalTable: "health_metric",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_health_metric_user_profile_UserProfileId",
                schema: "health",
                table: "health_metric",
                column: "UserProfileId",
                principalSchema: "health",
                principalTable: "user_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_progress_goal_GoalId",
                schema: "health",
                table: "progress",
                column: "GoalId",
                principalSchema: "health",
                principalTable: "goal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
