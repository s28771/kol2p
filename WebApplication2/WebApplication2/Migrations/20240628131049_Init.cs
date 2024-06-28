using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    IdColor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    IdModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.IdModel);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    IdModel = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Colors",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_IdModel",
                        column: x => x.IdModel,
                        principalTable: "Models",
                        principalColumn: "IdModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    IdCar_Rental = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Disscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.IdCar_Rental);
                    table.ForeignKey(
                        name: "FK_CarRentals_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Adress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "nnn", "nnn", "nnn" },
                    { 2, "kkkk", "kkk", "kkk" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "IdColor", "Name" },
                values: new object[,]
                {
                    { 1, "zolty" },
                    { 2, "pomarancz" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "IdModel", "Name" },
                values: new object[,]
                {
                    { 1, "xxxx" },
                    { 2, "ccc" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "IdColor", "IdModel", "Name", "PricePerDay", "Seats", "VIN" },
                values: new object[,]
                {
                    { 1, 1, 1, "bbbb", 150, 5, "bbbb" },
                    { 2, 1, 2, "bvbvb", 34, 3, "bvbvbv" }
                });

            migrationBuilder.InsertData(
                table: "CarRentals",
                columns: new[] { "IdCar_Rental", "DateFrom", "DateTo", "Disscount", "IdCar", "IdClient", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, 1, 1000 },
                    { 2, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 2, 420 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_IdCar",
                table: "CarRentals",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_IdClient",
                table: "CarRentals",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdColor",
                table: "Cars",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdModel",
                table: "Cars",
                column: "IdModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
