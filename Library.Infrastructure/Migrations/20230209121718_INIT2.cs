using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INIT2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Rental",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "RentalId",
                table: "_Books",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_BookId",
                table: "Rental",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental__Books_BookId",
                table: "Rental",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental__Books_BookId",
                table: "Rental");

            migrationBuilder.DropIndex(
                name: "IX_Rental_BookId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "_Books");
        }
    }
}
