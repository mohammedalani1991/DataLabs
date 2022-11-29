﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOS.Migrations
{
    public partial class edisettingcs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "SystemSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "SystemSettings");
        }
    }
}
