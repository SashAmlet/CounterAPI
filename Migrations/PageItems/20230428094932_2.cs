using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations.PageItems
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertBeforeId",
                table: "PageItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertBeforeId",
                table: "PageItems");
        }
    }
}
