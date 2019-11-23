using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class _1910 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisteredVancancies",
                table: "Hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailableVacancies",
                table: "Flight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisteredVancancies",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CarReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 10, 19, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(5607), new DateTime(2019, 10, 29, 11, 29, 45, 643, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvailableVacancies",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvailableVacancies",
                value: 40);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteredVancancies",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "AvailableVacancies",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "RegisteredVancancies",
                table: "Car");

            migrationBuilder.UpdateData(
                table: "CarReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 14, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(978), new DateTime(2019, 9, 24, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 14, 12, 33, 44, 35, DateTimeKind.Local).AddTicks(1484), new DateTime(2019, 9, 24, 12, 33, 44, 41, DateTimeKind.Local).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "HotelReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 14, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(3591), new DateTime(2019, 9, 24, 12, 33, 44, 43, DateTimeKind.Local).AddTicks(3604) });
        }
    }
}
