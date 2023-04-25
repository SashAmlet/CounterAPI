using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations
{
    /// <inheritdoc />
    public partial class _25042023_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Personalizations_PersonalizationId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Personalizations_PersonalizationId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Themes_PersonalizationId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Languages_PersonalizationId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "PersonalizationId",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "PersonalizationId",
                table: "Languages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalizationId",
                table: "Themes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalizationId",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Themes_PersonalizationId",
                table: "Themes",
                column: "PersonalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_PersonalizationId",
                table: "Languages",
                column: "PersonalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Personalizations_PersonalizationId",
                table: "Languages",
                column: "PersonalizationId",
                principalTable: "Personalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Personalizations_PersonalizationId",
                table: "Themes",
                column: "PersonalizationId",
                principalTable: "Personalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
