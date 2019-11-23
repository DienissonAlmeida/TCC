using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class OitoSetembro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 8, 19, 55, 15, 615, DateTimeKind.Local).AddTicks(9222), new DateTime(2019, 9, 18, 19, 55, 15, 618, DateTimeKind.Local).AddTicks(4496) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 3, 22, 53, 11, 491, DateTimeKind.Local).AddTicks(8022), new DateTime(2019, 9, 13, 22, 53, 11, 494, DateTimeKind.Local).AddTicks(876) });
        }
    }
}
