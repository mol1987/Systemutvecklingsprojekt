using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC3.Data.Migrations
{
    public partial class AddImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ProfileModel",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ProfileModel");
        }
    }
}
