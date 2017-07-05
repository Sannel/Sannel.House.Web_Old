using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sannel.House.Web.Data.Migrations
{
    public partial class AddedSensorEntriesTableFixedNameOfProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "TemperatureEntries",
                newName: "DateCreated");

            migrationBuilder.CreateTable(
                name: "SensorEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    SensorType = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Value2 = table.Column<double>(nullable: true),
                    Value3 = table.Column<double>(nullable: true),
                    Value4 = table.Column<double>(nullable: true),
                    Value5 = table.Column<double>(nullable: true),
                    Value6 = table.Column<double>(nullable: true),
                    Value7 = table.Column<double>(nullable: true),
                    Value8 = table.Column<double>(nullable: true),
                    Value9 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorEntries_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorEntries_DeviceId",
                table: "SensorEntries",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorEntries");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "TemperatureEntries",
                newName: "CreatedDateTime");
        }
    }
}
