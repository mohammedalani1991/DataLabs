using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOS.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnDescription",
                table: "CauseCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnTitle",
                table: "CauseCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "CauseCategory");

            migrationBuilder.DropColumn(
                name: "EnTitle",
                table: "CauseCategory");
        }
    }
}
