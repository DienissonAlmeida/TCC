using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eFlight.API.Migrations
{
    public partial class cityCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "Paris");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Madrid");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "City",
                value: "Las Vegas");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "City",
                value: "Nova Yorque");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "City",
                value: "Rio de Janeiro");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "City",
                value: "Paris");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Out", "Return" },
                values: new object[] { new DateTime(2019, 4, 10, 20, 7, 8, 13, DateTimeKind.Local).AddTicks(2025), new DateTime(2019, 4, 20, 20, 7, 8, 20, DateTimeKind.Local).AddTicks(5543) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Out", "Return" },
                values: new object[] { new DateTime(2019, 4, 9, 22, 36, 58, 839, DateTimeKind.Local).AddTicks(229), new DateTime(2019, 4, 19, 22, 36, 58, 841, DateTimeKind.Local).AddTicks(3169) });
        }
    }
}
