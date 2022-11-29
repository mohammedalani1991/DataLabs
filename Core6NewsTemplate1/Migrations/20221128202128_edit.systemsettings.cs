using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOS.Migrations
{
    public partial class editsystemsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnLongAbout",
                table: "SystemSettings",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongAbout",
                table: "SystemSettings",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnLongAbout",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "LongAbout",
                table: "SystemSettings");
        }
    }
}
