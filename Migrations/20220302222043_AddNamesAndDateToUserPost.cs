using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaSite.Migrations
{
    public partial class AddNamesAndDateToUserPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PostedName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostedName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PosterName",
                table: "Posts");
        }
    }
}
