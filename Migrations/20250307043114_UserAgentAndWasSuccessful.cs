using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginMonitorAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserAgentAndWasSuccessful : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "LoginMonitorEvents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "LoginMonitorEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WasSuccessful",
                table: "LoginMonitorEvents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "LoginMonitorEvents");

            migrationBuilder.DropColumn(
                name: "WasSuccessful",
                table: "LoginMonitorEvents");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "LoginMonitorEvents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
