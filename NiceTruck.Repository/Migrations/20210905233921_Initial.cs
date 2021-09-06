using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceTruck.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_truck_model",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ds_description = table.Column<string>(type: "TEXT", nullable: true),
                    st_active = table.Column<bool>(type: "INTEGER", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dt_updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_truck",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ds_description = table.Column<string>(type: "TEXT", nullable: true),
                    id_truck_model = table.Column<int>(type: "INTEGER", nullable: false),
                    cd_fab_year = table.Column<int>(type: "INTEGER", nullable: false),
                    cd_model_year = table.Column<int>(type: "INTEGER", nullable: false),
                    st_active = table.Column<bool>(type: "INTEGER", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dt_updated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_truck_tb_truck_model_id_truck_model",
                        column: x => x.id_truck_model,
                        principalTable: "tb_truck_model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_truck_model",
                columns: new[] { "id", "st_active", "dt_created", "dt_updated", "ds_description" },
                values: new object[] { 1, true, new DateTime(2021, 9, 5, 20, 39, 21, 204, DateTimeKind.Local).AddTicks(1100), null, "FH" });

            migrationBuilder.InsertData(
                table: "tb_truck_model",
                columns: new[] { "id", "st_active", "dt_created", "dt_updated", "ds_description" },
                values: new object[] { 2, true, new DateTime(2021, 9, 5, 20, 39, 21, 225, DateTimeKind.Local).AddTicks(8850), null, "FM" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_truck_id_truck_model",
                table: "tb_truck",
                column: "id_truck_model");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_truck");

            migrationBuilder.DropTable(
                name: "tb_truck_model");
        }
    }
}
