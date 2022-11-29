using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOS.Migrations
{
    public partial class addcausecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CauseCategoryId",
                table: "Cause",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CauseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cause_CauseCategoryId",
                table: "Cause",
                column: "CauseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cause_CauseCategory_CauseCategoryId",
                table: "Cause",
                column: "CauseCategoryId",
                principalTable: "CauseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cause_CauseCategory_CauseCategoryId",
                table: "Cause");

            migrationBuilder.DropTable(
                name: "CauseCategory");

            migrationBuilder.DropIndex(
                name: "IX_Cause_CauseCategoryId",
                table: "Cause");

            migrationBuilder.DropColumn(
                name: "CauseCategoryId",
                table: "Cause");
        }
    }
}
