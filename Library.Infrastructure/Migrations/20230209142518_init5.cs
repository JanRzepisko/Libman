using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Admins__Libraries_LibraryId",
                table: "_Admins");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__Libraries_LibraryId",
                table: "_Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "_Users",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "_Admins",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK__Admins__Libraries_LibraryId",
                table: "_Admins",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__Libraries_LibraryId",
                table: "_Users",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Admins__Libraries_LibraryId",
                table: "_Admins");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__Libraries_LibraryId",
                table: "_Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "_Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "_Admins",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK__Admins__Libraries_LibraryId",
                table: "_Admins",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Users__Libraries_LibraryId",
                table: "_Users",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
