using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserBlazorApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetRolesId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AspNetRolesId",
                table: "AspNetRoles",
                column: "AspNetRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_AspNetRolesId",
                table: "AspNetRoles",
                column: "AspNetRolesId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_AspNetRolesId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AspNetRolesId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AspNetRolesId",
                table: "AspNetRoles");
        }
    }
}
