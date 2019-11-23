using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class _191002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisteredVancancies",
                table: "Hotel",
                newName: "AvailableVacancies");

            migrationBuilder.RenameColumn(
                name: "RegisteredVancancies",
                table: "Car",
                newName: "AvailableVacancies");

            migrationBuilder.UpdateData(
                table: "CarReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 33, 19, 9, DateTimeKind.Local).AddTicks(3279), new DateTime(2019, 10, 29, 11, 33, 19, 9, DateTimeKind.Local).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 33, 19, 4, DateTimeKind.Local).AddTicks(1321), new DateTime(2019, 10, 29, 11, 33, 19, 6, DateTimeKind.Local).AddTicks(6586) });

            migrationBuilder.UpdateData(
                table: "HotelReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 33, 19, 9, DateTimeKind.Local).AddTicks(6789), new DateTime(2019, 10, 29, 11, 33, 19, 9, DateTimeKind.Local).AddTicks(6807) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableVacancies",
                table: "Hotel",
                newName: "RegisteredVancancies");

            migrationBuilder.RenameColumn(
                name: "AvailableVacancies",
                table: "Car",
                newName: "RegisteredVancancies");

            migrationBuilder.UpdateData(
                table: "CarReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(5607), new DateTime(2019, 10, 29, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 29, 45, 639, DateTimeKind.Local).AddTicks(5284), new DateTime(2019, 10, 29, 11, 29, 45, 641, DateTimeKind.Local).AddTicks(3688) });

            migrationBuilder.UpdateData(
                table: "HotelReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(8423), new DateTime(2019, 10, 29, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(8438) });
        }
    }
}
