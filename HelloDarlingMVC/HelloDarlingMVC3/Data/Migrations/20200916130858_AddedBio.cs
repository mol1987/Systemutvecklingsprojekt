using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC3.Data.Migrations
{
    public partial class AddedBio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "ProfileModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "ProfileModel");
        }
    }
}
