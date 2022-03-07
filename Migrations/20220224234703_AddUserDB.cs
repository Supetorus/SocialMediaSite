using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaSite.Migrations
{
	public partial class AddUserDB : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					Age = table.Column<int>(type: "int", nullable: false),
					Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.ID);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
