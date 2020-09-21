using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC3.Data.Migrations
{
    public partial class ChangedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModel_Appearance_Id",
                table: "ProfileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModel_Interests_Id",
                table: "ProfileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModel_Preference_Id",
                table: "ProfileModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Appearance_ProfileModel_ProfileModelId",
                table: "Appearance",
                column: "ProfileModelId",
                principalTable: "ProfileModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_ProfileModel_ProfileModelId",
                table: "Interests",
                column: "ProfileModelId",
                principalTable: "ProfileModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preference_ProfileModel_ProfileModelId",
                table: "Preference",
                column: "ProfileModelId",
                principalTable: "ProfileModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appearance_ProfileModel_ProfileModelId",
                table: "Appearance");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_ProfileModel_ProfileModelId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Preference_ProfileModel_ProfileModelId",
                table: "Preference");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModel_Appearance_Id",
                table: "ProfileModel",
                column: "Id",
                principalTable: "Appearance",
                principalColumn: "ProfileModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModel_Interests_Id",
                table: "ProfileModel",
                column: "Id",
                principalTable: "Interests",
                principalColumn: "ProfileModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModel_Preference_Id",
                table: "ProfileModel",
                column: "Id",
                principalTable: "Preference",
                principalColumn: "ProfileModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
