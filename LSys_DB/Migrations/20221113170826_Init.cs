using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSys_DB.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MQTTCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MQTTId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MQTTCredentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedulers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FrequencyType = table.Column<int>(type: "int", nullable: false),
                    FrequencyInterval = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    SetValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    MeasurementPeriod = table.Column<float>(type: "real", nullable: false),
                    Offset = table.Column<float>(type: "real", nullable: false),
                    SettingsUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WiFiCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GateWay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResetPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WiFiCredentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleList",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleList", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleList_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiFiCredentialsId = table.Column<int>(type: "int", nullable: false),
                    MQTTCredentialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_MQTTCredentials_MQTTCredentialsId",
                        column: x => x.MQTTCredentialsId,
                        principalTable: "MQTTCredentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devices_WiFiCredentials_WiFiCredentialsId",
                        column: x => x.WiFiCredentialsId,
                        principalTable: "WiFiCredentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dimmers_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SensorSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensors_SensorSettings_SensorSettingsId",
                        column: x => x.SensorSettingsId,
                        principalTable: "SensorSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDeviceList",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeviceList", x => new { x.UserId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_UserDeviceList_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDeviceList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimmerSchedulerList",
                columns: table => new
                {
                    DimmerId = table.Column<int>(type: "int", nullable: false),
                    SchedulerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimmerSchedulerList", x => new { x.SchedulerId, x.DimmerId });
                    table.ForeignKey(
                        name: "FK_DimmerSchedulerList_Dimmers_DimmerId",
                        column: x => x.DimmerId,
                        principalTable: "Dimmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimmerSchedulerList_Schedulers_SchedulerId",
                        column: x => x.SchedulerId,
                        principalTable: "Schedulers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_MQTTCredentialsId",
                table: "Devices",
                column: "MQTTCredentialsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_WiFiCredentialsId",
                table: "Devices",
                column: "WiFiCredentialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimmers_DeviceId",
                table: "Dimmers",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DimmerSchedulerList_DimmerId",
                table: "DimmerSchedulerList",
                column: "DimmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_SensorId",
                table: "Readings",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DeviceId",
                table: "Sensors",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorSettingsId",
                table: "Sensors",
                column: "SensorSettingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDeviceList_DeviceId",
                table: "UserDeviceList",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleList_RoleId",
                table: "UserRoleList",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DimmerSchedulerList");

            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "UserDeviceList");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "Dimmers");

            migrationBuilder.DropTable(
                name: "Schedulers");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "SensorSettings");

            migrationBuilder.DropTable(
                name: "MQTTCredentials");

            migrationBuilder.DropTable(
                name: "WiFiCredentials");
        }
    }
}
