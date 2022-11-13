using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSys_DB.Migrations
{
    public partial class DBaddGroupColumnToDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Devices");
        }
    }
}
