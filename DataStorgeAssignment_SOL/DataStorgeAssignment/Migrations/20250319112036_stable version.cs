using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorgeAssignment.Migrations
{
    /// <inheritdoc />
    public partial class stableversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Projects_ProjectEntityId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ProjectEntityId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectId",
                table: "Notes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Projects_ProjectId",
                table: "Notes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Projects_ProjectId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ProjectId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "ProjectEntityId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectEntityId",
                table: "Notes",
                column: "ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Projects_ProjectEntityId",
                table: "Notes",
                column: "ProjectEntityId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
