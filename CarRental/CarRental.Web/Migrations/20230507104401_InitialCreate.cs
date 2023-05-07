using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Web.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Cars",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                CarModelProp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Year = table.Column<int>(type: "int", nullable: false, comment: "Car production year"),
                LicencePlateNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                EngineType = table.Column<int>(type: "int", nullable: true),
                Transmission = table.Column<int>(type: "int", nullable: true),
                Addons = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                Color = table.Column<int>(type: "int", nullable: true),
                Displacement = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                FuelConsumption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                Kilometrage = table.Column<int>(type: "int", nullable: true),
                Doors = table.Column<int>(type: "int", nullable: true),
                SeatsNo = table.Column<int>(type: "int", nullable: true),
                Airbags = table.Column<int>(type: "int", nullable: true),
                PowerInKiloWatts = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cars", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                Pesel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Rentals",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                CarId = table.Column<int>(type: "int", nullable: false),
                BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                TotalCost = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rentals", x => x.Id);
                table.ForeignKey(
                    name: "FK_Rentals_Cars_CarId",
                    column: x => x.CarId,
                    principalTable: "Cars",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Rentals_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Rentals_CarId",
            table: "Rentals",
            column: "CarId");

        migrationBuilder.CreateIndex(
            name: "IX_Rentals_CustomerId",
            table: "Rentals",
            column: "CustomerId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Rentals");

        migrationBuilder.DropTable(
            name: "Cars");

        migrationBuilder.DropTable(
            name: "Customers");
    }
}
