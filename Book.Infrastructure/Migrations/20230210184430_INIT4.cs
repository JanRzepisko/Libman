using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INIT4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Books_Library_LibraryId",
                table: "_Books");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropIndex(
                name: "IX__Books_LibraryId",
                table: "_Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX__Books_LibraryId",
                table: "_Books",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK__Books_Library_LibraryId",
                table: "_Books",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
