using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class OitoSetembro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                column: "InputDate",
                value: new DateTime(2019, 9, 8, 23, 43, 25, 537, DateTimeKind.Utc).AddTicks(3315));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                column: "InputDate",
                value: new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
