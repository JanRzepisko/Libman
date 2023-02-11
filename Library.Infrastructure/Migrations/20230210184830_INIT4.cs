using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INIT4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Books__Authors_AuthorId",
                table: "_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental__Books_BookId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental__Libraries_LibraryId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental__Users_UserId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHistory__Books_BookId",
                table: "RentalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHistory__Libraries_LibraryId",
                table: "RentalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalHistory__Users_UserId",
                table: "RentalHistory");

            migrationBuilder.DropTable(
                name: "_Authors");

            migrationBuilder.DropIndex(
                name: "IX__Books_AuthorId",
                table: "_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalHistory",
                table: "RentalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rental",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "_Books");

            migrationBuilder.RenameTable(
                name: "RentalHistory",
                newName: "_RentalsHistory");

            migrationBuilder.RenameTable(
                name: "Rental",
                newName: "_Rentals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "_Books",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHistory_UserId",
                table: "_RentalsHistory",
                newName: "IX__RentalsHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHistory_LibraryId",
                table: "_RentalsHistory",
                newName: "IX__RentalsHistory_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalHistory_BookId",
                table: "_RentalsHistory",
                newName: "IX__RentalsHistory_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Rental_UserId",
                table: "_Rentals",
                newName: "IX__Rentals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rental_LibraryId",
                table: "_Rentals",
                newName: "IX__Rentals_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Rental_BookId",
                table: "_Rentals",
                newName: "IX__Rentals_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RentalId",
                table: "_Books",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "_Books",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "_RentalsHistory",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalDate",
                table: "_RentalsHistory",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalDate",
                table: "_Rentals",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK__RentalsHistory",
                table: "_RentalsHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Rentals",
                table: "_Rentals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Rentals__Books_BookId",
                table: "_Rentals",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Rentals__Libraries_LibraryId",
                table: "_Rentals",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Rentals__Users_UserId",
                table: "_Rentals",
                column: "UserId",
                principalTable: "_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__RentalsHistory__Books_BookId",
                table: "_RentalsHistory",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__RentalsHistory__Libraries_LibraryId",
                table: "_RentalsHistory",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__RentalsHistory__Users_UserId",
                table: "_RentalsHistory",
                column: "UserId",
                principalTable: "_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Rentals__Books_BookId",
                table: "_Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK__Rentals__Libraries_LibraryId",
                table: "_Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK__Rentals__Users_UserId",
                table: "_Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK__RentalsHistory__Books_BookId",
                table: "_RentalsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK__RentalsHistory__Libraries_LibraryId",
                table: "_RentalsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK__RentalsHistory__Users_UserId",
                table: "_RentalsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK__RentalsHistory",
                table: "_RentalsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Rentals",
                table: "_Rentals");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "_Books");

            migrationBuilder.RenameTable(
                name: "_RentalsHistory",
                newName: "RentalHistory");

            migrationBuilder.RenameTable(
                name: "_Rentals",
                newName: "Rental");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "_Books",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX__RentalsHistory_UserId",
                table: "RentalHistory",
                newName: "IX_RentalHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX__RentalsHistory_LibraryId",
                table: "RentalHistory",
                newName: "IX_RentalHistory_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX__RentalsHistory_BookId",
                table: "RentalHistory",
                newName: "IX_RentalHistory_BookId");

            migrationBuilder.RenameIndex(
                name: "IX__Rentals_UserId",
                table: "Rental",
                newName: "IX_Rental_UserId");

            migrationBuilder.RenameIndex(
                name: "IX__Rentals_LibraryId",
                table: "Rental",
                newName: "IX_Rental_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX__Rentals_BookId",
                table: "Rental",
                newName: "IX_Rental_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RentalId",
                table: "_Books",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "_Books",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReturnDate",
                table: "RentalHistory",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RentalDate",
                table: "RentalHistory",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RentalDate",
                table: "Rental",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalHistory",
                table: "RentalHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rental",
                table: "Rental",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "_Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX__Books_AuthorId",
                table: "_Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK__Books__Authors_AuthorId",
                table: "_Books",
                column: "AuthorId",
                principalTable: "_Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental__Books_BookId",
                table: "Rental",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental__Libraries_LibraryId",
                table: "Rental",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental__Users_UserId",
                table: "Rental",
                column: "UserId",
                principalTable: "_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHistory__Books_BookId",
                table: "RentalHistory",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHistory__Libraries_LibraryId",
                table: "RentalHistory",
                column: "LibraryId",
                principalTable: "_Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHistory__Users_UserId",
                table: "RentalHistory",
                column: "UserId",
                principalTable: "_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
