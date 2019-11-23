using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Passenger = table.Column<int>(maxLength: 10, nullable: false),
                    Transmission = table.Column<int>(maxLength: 10, nullable: false),
                    AirConditioning = table.Column<bool>(nullable: false),
                    Photos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Daily = table.Column<double>(nullable: false),
                    Stars = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputDate = table.Column<DateTime>(nullable: false),
                    OutputDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarReservation_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputDate = table.Column<DateTime>(nullable: false),
                    OutputDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightReservation_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputDate = table.Column<DateTime>(nullable: false),
                    OutputDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReservation_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackageReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputDate = table.Column<DateTime>(nullable: false),
                    OutputDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TravelPackageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackageReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPackageReservation_TravelPackage_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    FlightReservationId = table.Column<int>(nullable: true),
                    CarReservationId = table.Column<int>(nullable: true),
                    HotelReservationId = table.Column<int>(nullable: true),
                    TravelPackageReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_CarReservation_CarReservationId",
                        column: x => x.CarReservationId,
                        principalTable: "CarReservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_FlightReservation_FlightReservationId",
                        column: x => x.FlightReservationId,
                        principalTable: "FlightReservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_HotelReservation_HotelReservationId",
                        column: x => x.HotelReservationId,
                        principalTable: "HotelReservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_TravelPackageReservation_TravelPackageReservationId",
                        column: x => x.TravelPackageReservationId,
                        principalTable: "TravelPackageReservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "AirConditioning", "Brand", "Model", "Passenger", "Photos", "Transmission" },
                values: new object[,]
                {
                    { 1, true, "Citroen", "C4", 5, null, 0 },
                    { 2, true, "Ford", "New Fiesta", 5, null, 0 },
                    { 3, true, "Chevrolet", "Onix", 5, null, 0 },
                    { 4, true, "Hyundai", "HB20", 5, null, 0 },
                    { 5, true, "Volkswagen", "Gol", 5, null, 0 },
                    { 6, true, "Fiat", "Argo", 5, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "Company", "Destination", "Origin" },
                values: new object[] { 1, "Gol", "Paris", "São Paulo" });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "City", "Daily", "Name", "Stars" },
                values: new object[,]
                {
                    { 9, "Rio de Janeiro", 338.0, "Prodigy Hotel Santos Dumont Airport", 4 },
                    { 8, "Rio de Janeiro", 533.0, "Hotel Arpoador", 4 },
                    { 7, "Nova Yorque", 522.0, "YOTEL New York", 4 },
                    { 6, "Nova Yorque", 1.0580000000000001, "SIXTY SoHo", 4 },
                    { 2, "Paris", 338.0, "Hôtel La Manufacture", 4 },
                    { 4, "Roma", 611.0, "Best Western Plus Hotel Universo", 4 },
                    { 3, "Roma", 859.0, "Hotel Italia", 4 },
                    { 1, "Paris", 397.0, "Hotel Darcet", 4 },
                    { 5, "Roma", 592.0, "Hotel Colosseum", 4 }
                });

            migrationBuilder.InsertData(
                table: "TravelPackage",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pacote Buenos Aires" },
                    { 2, "Pacote Paris" }
                });

            migrationBuilder.InsertData(
                table: "FlightReservation",
                columns: new[] { "Id", "Description", "FlightId", "InputDate", "OutputDate" },
                values: new object[] { 1, "Reserva de Voo para Paris", 1, new DateTime(2019, 9, 3, 22, 53, 11, 491, DateTimeKind.Local).AddTicks(8022), new DateTime(2019, 9, 13, 22, 53, 11, 494, DateTimeKind.Local).AddTicks(876) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CarReservationId", "FlightReservationId", "HotelReservationId", "LastName", "Name", "Sex", "TravelPackageReservationId" },
                values: new object[] { 1, null, 1, null, "Silva", "José", 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_CarReservation_CarId",
                table: "CarReservation",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CarReservationId",
                table: "Customer",
                column: "CarReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FlightReservationId",
                table: "Customer",
                column: "FlightReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_HotelReservationId",
                table: "Customer",
                column: "HotelReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TravelPackageReservationId",
                table: "Customer",
                column: "TravelPackageReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightReservation_FlightId",
                table: "FlightReservation",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReservation_HotelId",
                table: "HotelReservation",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageReservation_TravelPackageId",
                table: "TravelPackageReservation",
                column: "TravelPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CarReservation");

            migrationBuilder.DropTable(
                name: "FlightReservation");

            migrationBuilder.DropTable(
                name: "HotelReservation");

            migrationBuilder.DropTable(
                name: "TravelPackageReservation");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TravelPackage");
        }
    }
}
