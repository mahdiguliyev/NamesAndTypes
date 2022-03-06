using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NamesAndTypes.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfWorker = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "NameOfWorker", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 6, 16, 49, 41, 771, DateTimeKind.Local).AddTicks(9172), "Ivan", "Programmer" },
                    { 2, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6535), "Petr", "Builder" },
                    { 3, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6550), "Vailiy", "Police" },
                    { 4, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6552), "Kolia", "Officer" },
                    { 5, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6554), "George", "Medical" },
                    { 6, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6555), "Olga", "Worker" },
                    { 7, new DateTime(2022, 3, 6, 16, 49, 41, 772, DateTimeKind.Local).AddTicks(6556), "Aria", "Programmer" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CreatedDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 6, 16, 49, 41, 773, DateTimeKind.Local).AddTicks(9889), "Programmer" },
                    { 2, new DateTime(2022, 3, 6, 16, 49, 41, 774, DateTimeKind.Local).AddTicks(356), "Builder" },
                    { 3, new DateTime(2022, 3, 6, 16, 49, 41, 774, DateTimeKind.Local).AddTicks(361), "Police" },
                    { 4, new DateTime(2022, 3, 6, 16, 49, 41, 774, DateTimeKind.Local).AddTicks(362), "Officer" },
                    { 5, new DateTime(2022, 3, 6, 16, 49, 41, 774, DateTimeKind.Local).AddTicks(363), "Worker" },
                    { 6, new DateTime(2022, 3, 6, 16, 49, 41, 774, DateTimeKind.Local).AddTicks(364), "Medical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NameOfWorker",
                table: "Employees",
                column: "NameOfWorker",
                unique: true,
                filter: "[NameOfWorker] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
