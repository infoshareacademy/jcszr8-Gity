using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastLoggings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastLogged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastLoggings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LastLoggings",
                columns: new[] { "Id", "LastLogged", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 8, 18, 35, 43, 307, DateTimeKind.Local).AddTicks(7399), 1 },
                    { 2, new DateTime(2023, 5, 9, 19, 45, 43, 307, DateTimeKind.Local).AddTicks(7446), 2 },
                    { 3, new DateTime(2023, 5, 10, 20, 55, 43, 307, DateTimeKind.Local).AddTicks(7449), 3 },
                    { 4, new DateTime(2023, 5, 11, 18, 45, 43, 307, DateTimeKind.Local).AddTicks(7452), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastLoggings_UserId",
                table: "LastLoggings",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastLoggings");
        }
    }
}
