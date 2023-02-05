using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSys_DataAccess.Migrations
{
    public partial class DimmersToRelays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DimmerSchedulerList");

            migrationBuilder.DropTable(
                name: "Dimmers");

            migrationBuilder.RenameColumn(
                name: "ResetPassword",
                table: "WiFiCredentials",
                newName: "SecurityPassword");

            migrationBuilder.CreateTable(
                name: "Relays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstChannelState = table.Column<bool>(type: "bit", nullable: false),
                    SecondChannelState = table.Column<bool>(type: "bit", nullable: false),
                    ThirdChannelState = table.Column<bool>(type: "bit", nullable: false),
                    FourthChannelState = table.Column<bool>(type: "bit", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relays_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelaySchedulerList",
                columns: table => new
                {
                    RelayId = table.Column<int>(type: "int", nullable: false),
                    SchedulerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaySchedulerList", x => new { x.SchedulerId, x.RelayId });
                    table.ForeignKey(
                        name: "FK_RelaySchedulerList_Relays_RelayId",
                        column: x => x.RelayId,
                        principalTable: "Relays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelaySchedulerList_Schedulers_SchedulerId",
                        column: x => x.SchedulerId,
                        principalTable: "Schedulers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relays_DeviceId",
                table: "Relays",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RelaySchedulerList_RelayId",
                table: "RelaySchedulerList",
                column: "RelayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelaySchedulerList");

            migrationBuilder.DropTable(
                name: "Relays");

            migrationBuilder.RenameColumn(
                name: "SecurityPassword",
                table: "WiFiCredentials",
                newName: "ResetPassword");

            migrationBuilder.CreateTable(
                name: "Dimmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
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
                name: "DimmerSchedulerList",
                columns: table => new
                {
                    SchedulerId = table.Column<int>(type: "int", nullable: false),
                    DimmerId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Dimmers_DeviceId",
                table: "Dimmers",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DimmerSchedulerList_DimmerId",
                table: "DimmerSchedulerList",
                column: "DimmerId");
        }
    }
}
