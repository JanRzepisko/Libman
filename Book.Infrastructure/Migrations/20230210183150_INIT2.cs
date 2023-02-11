using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INIT2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Books__Libraries_LibraryId",
                table: "_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Libraries",
                table: "_Libraries");

            migrationBuilder.RenameTable(
                name: "_Libraries",
                newName: "Library");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Library",
                table: "Library",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Books_Library_LibraryId",
                table: "_Books",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Books_Library_LibraryId",
                table: "_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Library",
                table: "Library");

            migrationBuilder.RenameTable(
                name: "Library",
                newName: "_Libraries");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Libraries",
                table: "_Libraries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Books__Libraries_LibraryId",
                table: "_Books",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
