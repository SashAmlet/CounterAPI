using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations.PageItems
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventListeners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventListeners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageItemId = table.Column<int>(type: "int", nullable: false),
                    FirstWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventListeners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventListeners_PageItems_PageItemId",
                        column: x => x.PageItemId,
                        principalTable: "PageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventListeners_PageItemId",
                table: "EventListeners",
                column: "PageItemId");
        }
    }
}
