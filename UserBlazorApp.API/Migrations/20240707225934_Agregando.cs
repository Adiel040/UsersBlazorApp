using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserBlazorApp.API.Migrations
{
    /// <inheritdoc />
    public partial class Agregando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetRoleClaims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_UserId",
                table: "AspNetRoleClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetUsers_UserId",
                table: "AspNetRoleClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetUsers_UserId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_UserId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "Id");
        }
    }
}
