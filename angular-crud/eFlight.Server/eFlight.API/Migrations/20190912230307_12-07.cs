using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class _1207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "Company", "Destination", "Origin" },
                values: new object[] { 2, "TAM", "Nova Iorque", "Rio de Janeiro" });

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 12, 20, 3, 6, 637, DateTimeKind.Local).AddTicks(3372), new DateTime(2019, 9, 22, 20, 3, 6, 638, DateTimeKind.Local).AddTicks(7750) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "FlightReservation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InputDate", "OutputDate" },
                values: new object[] { new DateTime(2019, 9, 8, 23, 43, 25, 537, DateTimeKind.Utc).AddTicks(3315), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
