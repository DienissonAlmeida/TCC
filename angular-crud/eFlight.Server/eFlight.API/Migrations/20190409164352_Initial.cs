using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Passengers = table.Column<int>(maxLength: 10, nullable: false),
                    Transmission = table.Column<int>(maxLength: 10, nullable: false),
                    AirConditioning = table.Column<bool>(nullable: false),
                    Photos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
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
                    table.PrimaryKey("PK_Hotels", x => x.Id);
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
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    HotelId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AirConditioning", "Brand", "Model", "Passengers", "Photos", "Transmission" },
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
                table: "Hotels",
                columns: new[] { "Id", "City", "Daily", "Name", "Stars" },
                values: new object[,]
                {
                    { 1, "Paris", 397.0, "Hotel Darcet", 0 },
                    { 2, "Paris", 338.0, "Hôtel La Manufacture", 0 },
                    { 3, "Roma", 859.0, "Hotel Italia", 0 },
                    { 4, "Roma", 611.0, "Best Western Plus Hotel Universo", 0 },
                    { 5, "Roma", 592.0, "Hotel Colosseum", 0 },
                    { 6, "Nova Yorque", 1.0580000000000001, "SIXTY SoHo", 0 },
                    { 7, "Nova Yorque", 522.0, "YOTEL New York", 0 },
                    { 8, "Rio de Janeiro", 533.0, "Hotel Arpoador", 0 },
                    { 9, "Rio de Janeiro", 338.0, "Prodigy Hotel Santos Dumont Airport", 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Cpf", "Name" },
                values: new object[] { 1, "03198210054", "Dienisson" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
