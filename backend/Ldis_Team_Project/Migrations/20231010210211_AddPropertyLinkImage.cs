using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ldis_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyLinkImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAvatarLink",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAvatarLink",
                table: "Users");
        }
    }
}
