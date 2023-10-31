using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ldis_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertiesUsersAndChats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chats_ChatIdId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UserIdId",
                table: "ChatUser");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "ChatUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ChatIdId",
                table: "ChatUser",
                newName: "ChatsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_UserIdId",
                table: "ChatUser",
                newName: "IX_ChatUser_UsersId");

            migrationBuilder.CreateTable(
                name: "NoRegisterUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRegisterUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoRegisterUserUser",
                columns: table => new
                {
                    PersonalMessageIdId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonalMessageNoRegisterUserIdId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRegisterUserUser", x => new { x.PersonalMessageIdId, x.PersonalMessageNoRegisterUserIdId });
                    table.ForeignKey(
                        name: "FK_NoRegisterUserUser_NoRegisterUsers_PersonalMessageNoRegisterUserIdId",
                        column: x => x.PersonalMessageNoRegisterUserIdId,
                        principalTable: "NoRegisterUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoRegisterUserUser_Users_PersonalMessageIdId",
                        column: x => x.PersonalMessageIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoRegisterUserUser_PersonalMessageNoRegisterUserIdId",
                table: "NoRegisterUserUser",
                column: "PersonalMessageNoRegisterUserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chats_ChatsId",
                table: "ChatUser",
                column: "ChatsId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chats_ChatsId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser");

            migrationBuilder.DropTable(
                name: "NoRegisterUserUser");

            migrationBuilder.DropTable(
                name: "NoRegisterUsers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ChatUser",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "ChatsId",
                table: "ChatUser",
                newName: "ChatIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                newName: "IX_ChatUser_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chats_ChatIdId",
                table: "ChatUser",
                column: "ChatIdId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UserIdId",
                table: "ChatUser",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
