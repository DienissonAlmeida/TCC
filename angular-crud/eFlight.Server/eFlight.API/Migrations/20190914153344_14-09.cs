using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class _1409 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarReservation",
                columns: new[] { "Id", "CarId", "InputDate", "Name", "OutputDate" },
                values: new object[] { 1, 1, new DateTime(2019, 9, 14, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(978), "Dienisson", new DateTime(2019, 9, 24, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 14, 12, 33, 44, 35, DateTimeKind.Local).AddTicks(1484), new DateTime(2019, 9, 24, 12, 33, 44, 41, DateTimeKind.Local).AddTicks(1943) });

            migrationBuilder.InsertData(
                table: "HotelReservation",
                columns: new[] { "Id", "Description", "HotelId", "InputDate", "OutputDate" },
                values: new object[] { 1, "Reserva de hotel em Paris", 1, new DateTime(2019, 9, 14, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(3591), new DateTime(2019, 9, 24, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(3604) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarReservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelReservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 12, 20, 3, 6, 637, DateTimeKind.Local).AddTicks(3372), new DateTime(2019, 9, 22, 20, 3, 6, 638, DateTimeKind.Local).AddTicks(7750) });
        }
    }
}
