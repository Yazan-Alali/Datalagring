using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorgeAssignment.Migrations
{
    /// <inheritdoc />
    public partial class lastupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Projects_ProjectEntityId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ProjectEntityId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Notes");
        }
    }
}
