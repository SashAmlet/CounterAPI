using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations.PageItems
{
    /// <inheritdoc />
    public partial class _0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageItems_PageItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventListeners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageItemId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PageItemAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageItemAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageItemAttributes_PageItems_PageItemId",
                        column: x => x.PageItemId,
                        principalTable: "PageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventListeners_PageItemId",
                table: "EventListeners",
                column: "PageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PageItemAttributes_PageItemId",
                table: "PageItemAttributes",
                column: "PageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PageItems_ParentId",
                table: "PageItems",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventListeners");

            migrationBuilder.DropTable(
                name: "PageItemAttributes");

            migrationBuilder.DropTable(
                name: "PageItems");
        }
    }
}
