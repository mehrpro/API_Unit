using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Unit.Migrations
{
    public partial class DBCretor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReporterStations",
                columns: table => new
                {
                    ReporterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterTitel = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporterStations", x => x.ReporterID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagTitel = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "TagRegistereds",
                columns: table => new
                {
                    RowID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagID_FK = table.Column<int>(type: "int", nullable: false),
                    RegisterdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewRegistered = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ReporterID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagRegistereds", x => x.RowID);
                    table.ForeignKey(
                        name: "FK_TagRegistereds_ReporterStations_ReporterID_FK",
                        column: x => x.ReporterID_FK,
                        principalTable: "ReporterStations",
                        principalColumn: "ReporterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagRegistereds_Tags_TagID_FK",
                        column: x => x.TagID_FK,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagRegistereds_ReporterID_FK",
                table: "TagRegistereds",
                column: "ReporterID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TagRegistereds_TagID_FK",
                table: "TagRegistereds",
                column: "TagID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagRegistereds");

            migrationBuilder.DropTable(
                name: "ReporterStations");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
