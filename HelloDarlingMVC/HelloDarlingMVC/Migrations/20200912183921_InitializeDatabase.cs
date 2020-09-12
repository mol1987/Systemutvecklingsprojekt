using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(32)", nullable: false),
                    IdentityNO = table.Column<string>(type: "varchar(12)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    UsersCategory = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(type: "varchar(64)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Appearance",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    HairColor = table.Column<string>(type: "varchar(32)", nullable: true),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Appearance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Interests", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Interests_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    UserMatchingId = table.Column<int>(nullable: false),
                    UserMatcheeId = table.Column<int>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    Favorite = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => new { x.UserMatchingId, x.UserMatcheeId });
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
                    SenderId = table.Column<int>(nullable: false),
                    ReceiverId = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    MessageStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessagesId);
                    table.ForeignKey(
                        name: "FK_Messages_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PreferenceId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Preference_User_UserId",
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
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Messages_UserId",
                table: "User",
                column: "UserId",
                principalTable: "Messages",
                principalColumn: "MessagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_SenderId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
