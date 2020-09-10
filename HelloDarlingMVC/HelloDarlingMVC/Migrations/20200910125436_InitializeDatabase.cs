using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appearance",
                columns: table => new
                {
                    AppearanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairColor = table.Column<string>(type: "varchar(32)", nullable: true),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.AppearanceId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sports = table.Column<string>(type: "varchar(32)", nullable: true),
                    Music = table.Column<string>(type: "varchar(32)", nullable: true),
                    Movies = table.Column<string>(type: "varchar(32)", nullable: true),
                    Books = table.Column<string>(type: "varchar(32)", nullable: true),
                    Language = table.Column<string>(type: "varchar(32)", nullable: true),
                    TVgame = table.Column<string>(type: "varchar(32)", nullable: true),
                    Cars = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestsId);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.PreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNO = table.Column<string>(type: "varchar(12)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    UsersCategory = table.Column<int>(maxLength: 5, nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(type: "varchar(64)", nullable: false),
                    Gender = table.Column<int>(maxLength: 3, nullable: false),
                    Status = table.Column<int>(maxLength: 3, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", nullable: false),
                    UserAppearanceAppearanceId = table.Column<int>(nullable: true),
                    UserInterestsInterestsId = table.Column<int>(nullable: true),
                    UserPreferencePreferenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Appearance_UserAppearanceAppearanceId",
                        column: x => x.UserAppearanceAppearanceId,
                        principalTable: "Appearance",
                        principalColumn: "AppearanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Interests_UserInterestsInterestsId",
                        column: x => x.UserInterestsInterestsId,
                        principalTable: "Interests",
                        principalColumn: "InterestsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Preference_UserPreferencePreferenceId",
                        column: x => x.UserPreferencePreferenceId,
                        principalTable: "Preference",
                        principalColumn: "PreferenceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchingUserId = table.Column<int>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    Favorite = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    MessageStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => new { x.UserId, x.MessagesId });
                    table.ForeignKey(
                        name: "FK_Messages_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_UserId",
                table: "Match",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserAppearanceAppearanceId",
                table: "User",
                column: "UserAppearanceAppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInterestsInterestsId",
                table: "User",
                column: "UserInterestsInterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserPreferencePreferenceId",
                table: "User",
                column: "UserPreferencePreferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Preference");
        }
    }
}
