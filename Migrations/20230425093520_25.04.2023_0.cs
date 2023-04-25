﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations
{
    /// <inheritdoc />
    public partial class _25042023_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notifications = table.Column<bool>(type: "bit", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfProblems = table.Column<int>(type: "int", nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    Fructions = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfSolved = table.Column<int>(type: "int", nullable: false),
                    NumOfUnsolved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ukranian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Personalizations_PersonalizationId",
                        column: x => x.PersonalizationId,
                        principalTable: "Personalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    White = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_Personalizations_PersonalizationId",
                        column: x => x.PersonalizationId,
                        principalTable: "Personalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Personalizations_PersonalizationId",
                        column: x => x.PersonalizationId,
                        principalTable: "Personalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateListId = table.Column<int>(type: "int", nullable: false),
                    TemplateStatisticsId = table.Column<int>(type: "int", nullable: false),
                    TemplateSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Templates_TemplateLists_TemplateListId",
                        column: x => x.TemplateListId,
                        principalTable: "TemplateLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Templates_TemplateSettings_TemplateSettingsId",
                        column: x => x.TemplateSettingsId,
                        principalTable: "TemplateSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Templates_TemplateStatistics_TemplateStatisticsId",
                        column: x => x.TemplateStatisticsId,
                        principalTable: "TemplateStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_PersonalizationId",
                table: "Languages",
                column: "PersonalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateLists_UserId",
                table: "TemplateLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateListId",
                table: "Templates",
                column: "TemplateListId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateSettingsId",
                table: "Templates",
                column: "TemplateSettingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateStatisticsId",
                table: "Templates",
                column: "TemplateStatisticsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Themes_PersonalizationId",
                table: "Themes",
                column: "PersonalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalizationId",
                table: "Users",
                column: "PersonalizationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "TemplateLists");

            migrationBuilder.DropTable(
                name: "TemplateSettings");

            migrationBuilder.DropTable(
                name: "TemplateStatistics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Personalizations");
        }
    }
}