using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class Admins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Users",
                table: "_Users");

            migrationBuilder.RenameTable(
                name: "_Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "_Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users",
                table: "_Users",
                column: "Id");
        }
    }
}
