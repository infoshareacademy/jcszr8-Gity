using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Web.Migrations
{
    public partial class ZmianyRaportow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VisitedCars_UserId",
                table: "VisitedCars");

            migrationBuilder.DropIndex(
                name: "IX_LastLoggings_UserId",
                table: "LastLoggings");

            migrationBuilder.DeleteData(
                table: "LastLoggings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LastLoggings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LastLoggings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LastLoggings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "VisitedCars",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "LastLoggings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "LastLoggings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "LastLoggings",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "LastLoggings");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "LastLoggings");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "LastLoggings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "VisitedCars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.InsertData(
                table: "LastLoggings",
                columns: new[] { "Id", "LastLogged", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 13, 49, 46, 504, DateTimeKind.Local).AddTicks(4911), 1 },
                    { 2, new DateTime(2023, 5, 16, 14, 59, 46, 504, DateTimeKind.Local).AddTicks(4942), 2 },
                    { 3, new DateTime(2023, 5, 17, 16, 9, 46, 504, DateTimeKind.Local).AddTicks(4944), 3 },
                    { 4, new DateTime(2023, 5, 18, 13, 59, 46, 504, DateTimeKind.Local).AddTicks(4945), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitedCars_UserId",
                table: "VisitedCars",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LastLoggings_UserId",
                table: "LastLoggings",
                column: "UserId",
                unique: true);
        }
    }
}
