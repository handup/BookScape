using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookScape.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMinor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItems_AuthorItems_AuthorId1",
                table: "BookItems");

            migrationBuilder.DropIndex(
                name: "IX_BookItems_AuthorId1",
                table: "BookItems");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "BookItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "BookItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AuthorItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AuthorItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AuthorItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookItems_AuthorId",
                table: "BookItems",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItems_AuthorItems_AuthorId",
                table: "BookItems",
                column: "AuthorId",
                principalTable: "AuthorItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItems_AuthorItems_AuthorId",
                table: "BookItems");

            migrationBuilder.DropIndex(
                name: "IX_BookItems_AuthorId",
                table: "BookItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "BookItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<long>(
                name: "AuthorId1",
                table: "BookItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AuthorItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AuthorItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AuthorItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_BookItems_AuthorId1",
                table: "BookItems",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItems_AuthorItems_AuthorId1",
                table: "BookItems",
                column: "AuthorId1",
                principalTable: "AuthorItems",
                principalColumn: "Id");
        }
    }
}
