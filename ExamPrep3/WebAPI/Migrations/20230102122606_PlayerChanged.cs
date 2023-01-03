using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamName",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamName",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName1",
                table: "Players",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamName1",
                table: "Players",
                column: "TeamName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamName1",
                table: "Players",
                column: "TeamName1",
                principalTable: "Teams",
                principalColumn: "TeamName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamName1",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamName1",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamName1",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Players",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamName",
                table: "Players",
                column: "TeamName");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamName",
                table: "Players",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "TeamName");
        }
    }
}
