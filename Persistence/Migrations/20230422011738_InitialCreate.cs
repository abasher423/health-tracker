using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "health");

            migrationBuilder.CreateTable(
                name: "user_profile",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<decimal>(type: "numeric", nullable: false),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_profile_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "health_metric",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    unit_of_measurement = table.Column<string>(type: "text", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_health_metric_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_health_metric_user_profile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "health",
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "health_data_entry",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    HealthMetricId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_health_data_entry_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_health_data_entry_health_metric_HealthMetricId",
                        column: x => x.HealthMetricId,
                        principalSchema: "health",
                        principalTable: "health_metric",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goal",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    target = table.Column<decimal>(type: "numeric", nullable: false),
                    HealthDataEntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goal_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_goal_health_data_entry_HealthDataEntryId",
                        column: x => x.HealthDataEntryId,
                        principalSchema: "health",
                        principalTable: "health_data_entry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "progress",
                schema: "health",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    GoalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_progress_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_progress_goal_GoalId",
                        column: x => x.GoalId,
                        principalSchema: "health",
                        principalTable: "goal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_goal_HealthDataEntryId",
                schema: "health",
                table: "goal",
                column: "HealthDataEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_health_data_entry_HealthMetricId",
                schema: "health",
                table: "health_data_entry",
                column: "HealthMetricId");

            migrationBuilder.CreateIndex(
                name: "IX_health_metric_UserProfileId",
                schema: "health",
                table: "health_metric",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_progress_GoalId",
                schema: "health",
                table: "progress",
                column: "GoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "progress",
                schema: "health");

            migrationBuilder.DropTable(
                name: "goal",
                schema: "health");

            migrationBuilder.DropTable(
                name: "health_data_entry",
                schema: "health");

            migrationBuilder.DropTable(
                name: "health_metric",
                schema: "health");

            migrationBuilder.DropTable(
                name: "user_profile",
                schema: "health");
        }
    }
}
