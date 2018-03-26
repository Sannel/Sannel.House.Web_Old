using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sannel.House.Web.Data.Migrations
{
	public partial class Added10thValue : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<double>(
				name: "Value10",
				table: "SensorEntries",
				type: "REAL",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Value10",
				table: "SensorEntries");
		}
	}
}
