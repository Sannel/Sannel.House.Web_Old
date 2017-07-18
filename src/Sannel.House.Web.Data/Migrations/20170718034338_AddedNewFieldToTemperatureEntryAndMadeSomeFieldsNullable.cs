using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class AddedNewFieldToTemperatureEntryAndMadeSomeFieldsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Pressure",
                table: "TemperatureEntries",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "TemperatureEntries",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "RelativeHumidity",
                table: "TemperatureEntries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelativeHumidity",
                table: "TemperatureEntries");

            migrationBuilder.AlterColumn<double>(
                name: "Pressure",
                table: "TemperatureEntries",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "TemperatureEntries",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
