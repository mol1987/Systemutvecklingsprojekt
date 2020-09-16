using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloDarlingMVC3.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appearance",
                columns: table => new
                {
                    ProfileModelId = table.Column<Guid>(nullable: false),
                    HairColor = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.ProfileModelId);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationsId = table.Column<Guid>(nullable: false),
                    MessagesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationsId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    ProfileModelId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Interests", x => x.ProfileModelId);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    ProfileModelId = table.Column<Guid>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.ProfileModelId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityNO = table.Column<string>(type: "varchar(12)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", nullable: false),
                    UsersCategory = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(type: "varchar(64)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileModel_Appearance_Id",
                        column: x => x.Id,
                        principalTable: "Appearance",
                        principalColumn: "ProfileModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileModel_Interests_Id",
                        column: x => x.Id,
                        principalTable: "Interests",
                        principalColumn: "ProfileModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileModel_Preference_Id",
                        column: x => x.Id,
                        principalTable: "Preference",
                        principalColumn: "ProfileModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Profile1Id = table.Column<Guid>(nullable: false),
                    Profile2Id = table.Column<Guid>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    Favorite = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => new { x.Profile1Id, x.Profile2Id });
                    table.ForeignKey(
                        name: "FK_Match_ProfileModel_Profile1Id",
                        column: x => x.Profile1Id,
                        principalTable: "ProfileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_ProfileModel_Profile2Id",
                        column: x => x.Profile2Id,
                        principalTable: "ProfileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    MessageStatus = table.Column<int>(nullable: false),
                    ConversationsId = table.Column<Guid>(nullable: true),
                    ProfileModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationsId",
                        column: x => x.ConversationsId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_ProfileModel_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "ProfileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserConversation",
                columns: table => new
                {
                    ProfileModelId = table.Column<Guid>(nullable: false),
                    ConversationsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConversation", x => new { x.ProfileModelId, x.ConversationsId });
                    table.ForeignKey(
                        name: "FK_UserConversation_Conversations_ConversationsId",
                        column: x => x.ConversationsId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConversation_ProfileModel_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "ProfileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationsMessages",
                columns: table => new
                {
                    ConversationsId = table.Column<Guid>(nullable: false),
                    MessageID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationsMessages", x => new { x.ConversationsId, x.MessageID });
                    table.ForeignKey(
                        name: "FK_ConversationsMessages_Conversations_ConversationsId",
                        column: x => x.ConversationsId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationsMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationsMessages_MessageID",
                table: "ConversationsMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Profile2Id",
                table: "Match",
                column: "Profile2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationsId",
                table: "Messages",
                column: "ConversationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProfileModelId",
                table: "Messages",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_ConversationsId",
                table: "UserConversation",
                column: "ConversationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationsMessages");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "UserConversation");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "ProfileModel");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Preference");
        }
    }
}
