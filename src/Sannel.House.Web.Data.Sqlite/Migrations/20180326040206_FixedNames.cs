using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sannel.House.Web.Data.Migrations
{
	public partial class FixedNames : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "DeviceIds");

			migrationBuilder.CreateTable(
				name: "AlternateDeviceIds",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					DateCreated = table.Column<DateTime>(nullable: false),
					DeviceId = table.Column<int>(nullable: false),
					Uuid = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlternateDeviceIds", x => x.Id);
					table.ForeignKey(
						name: "FK_AlternateDeviceIds_Devices_DeviceId",
						column: x => x.DeviceId,
						principalTable: "Devices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_AlternateDeviceIds_DeviceId",
				table: "AlternateDeviceIds",
				column: "DeviceId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AlternateDeviceIds");

			migrationBuilder.CreateTable(
				name: "DeviceIds",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					DateCreated = table.Column<DateTime>(nullable: false),
					DeviceId = table.Column<int>(nullable: false),
					NetworkAdapterGuidId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DeviceIds", x => x.Id);
					table.ForeignKey(
						name: "FK_DeviceIds_Devices_DeviceId",
						column: x => x.DeviceId,
						principalTable: "Devices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_DeviceIds_DeviceId",
				table: "DeviceIds",
				column: "DeviceId");
		}
	}
}
