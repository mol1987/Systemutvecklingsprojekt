using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC3.Data.Migrations
{
    public partial class AddedAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ProfileModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ProfileModel");
        }
    }
}
