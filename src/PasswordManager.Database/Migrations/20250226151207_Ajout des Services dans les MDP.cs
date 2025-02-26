using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class AjoutdesServicesdanslesMDP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Passwords",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "Passwords");
        }
    }
}
