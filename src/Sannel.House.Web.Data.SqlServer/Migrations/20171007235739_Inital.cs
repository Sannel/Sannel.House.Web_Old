using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sannel.House.Web.Data.Migrations
{
	public partial class Inital : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "ApplicationLogEntries",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ApplicationId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					DeviceId = table.Column<int>(type: "int", nullable: true),
					Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ApplicationLogEntries", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Devices",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
					DisplayOrder = table.Column<int>(type: "int", nullable: false),
					IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
					MacAddress = table.Column<long>(type: "bigint", nullable: true),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Devices", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "RefreshTokens",
				columns: table => new
				{
					RefreshTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
				});

			migrationBuilder.CreateTable(
				name: "TemperatureSettings",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					CoolTemperatureC = table.Column<double>(type: "float", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
					DayOfWeek = table.Column<int>(type: "int", nullable: true),
					EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
					HeatTemperatureC = table.Column<double>(type: "float", nullable: false),
					IsTimeOnly = table.Column<bool>(type: "bit", nullable: false),
					Month = table.Column<int>(type: "int", nullable: true),
					StartTime = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TemperatureSettings", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SensorEntries",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					DeviceId = table.Column<int>(type: "int", nullable: false),
					SensorType = table.Column<int>(type: "int", nullable: false),
					Value = table.Column<double>(type: "float", nullable: false),
					Value2 = table.Column<double>(type: "float", nullable: true),
					Value3 = table.Column<double>(type: "float", nullable: true),
					Value4 = table.Column<double>(type: "float", nullable: true),
					Value5 = table.Column<double>(type: "float", nullable: true),
					Value6 = table.Column<double>(type: "float", nullable: true),
					Value7 = table.Column<double>(type: "float", nullable: true),
					Value8 = table.Column<double>(type: "float", nullable: true),
					Value9 = table.Column<double>(type: "float", nullable: true)
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

			migrationBuilder.CreateTable(
				name: "TemperatureEntries",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					DeviceId = table.Column<int>(type: "int", nullable: false),
					Humidity = table.Column<double>(type: "float", nullable: true),
					Pressure = table.Column<double>(type: "float", nullable: true),
					TemperatureCelsius = table.Column<double>(type: "float", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TemperatureEntries", x => x.Id);
					table.ForeignKey(
						name: "FK_TemperatureEntries_Devices_DeviceId",
						column: x => x.DeviceId,
						principalTable: "Devices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_SensorEntries_DeviceId",
				table: "SensorEntries",
				column: "DeviceId");

			migrationBuilder.CreateIndex(
				name: "IX_TemperatureEntries_DeviceId",
				table: "TemperatureEntries",
				column: "DeviceId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ApplicationLogEntries");

			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "RefreshTokens");

			migrationBuilder.DropTable(
				name: "SensorEntries");

			migrationBuilder.DropTable(
				name: "TemperatureEntries");

			migrationBuilder.DropTable(
				name: "TemperatureSettings");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "Devices");
		}
	}
}
