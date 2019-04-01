using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingStrategyTurism.API.Migrations
{
    public partial class seedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Daily",
                table: "Hotels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Transmission",
                value: 1);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AirConditioning", "Brand", "Model", "Passengers", "Photos", "Transmission" },
                values: new object[,]
                {
                    { 2, true, "Ford", "New Fiesta", 5, null, 1 },
                    { 3, true, "Chevrolet", "Onix", 5, null, 1 },
                    { 4, true, "Hyundai", "HB20", 5, null, 1 },
                    { 5, true, "Volkswagen", "Gol", 5, null, 1 },
                    { 6, true, "Fiat", "Argo", 5, null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Daily", "Name", "Stars" },
                values: new object[] { "Paris", 397.0, "Hotel Darcet", 0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Daily", "Name", "Stars" },
                values: new object[] { "Paris", 338.0, "Hôtel La Manufacture", 0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Daily", "Name", "Stars" },
                values: new object[,]
                {
                    { 3, "Roma", 859.0, "Hotel Italia", 0 },
                    { 4, "Roma", 611.0, "Best Western Plus Hotel Universo", 0 },
                    { 5, "Roma", 592.0, "Hotel Colosseum", 0 },
                    { 6, "Nova Yorque", 1.0580000000000001, "SIXTY SoHo", 0 },
                    { 7, "Nova Yorque", 522.0, "YOTEL New York", 0 },
                    { 8, "Rio de Janeiro", 533.0, "Hotel Arpoador", 0 },
                    { 9, "Rio de Janeiro", 338.0, "Prodigy Hotel Santos Dumont Airport", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Daily",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Transmission",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "Stars" },
                values: new object[] { "Vacaria", "San Bernardo", 4 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "Stars" },
                values: new object[] { "Lages", "Lages Plaza Hotel", 4 });
        }
    }
}
