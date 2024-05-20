using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class DATa754 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosteId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "ReposId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "SupplementId",
                table: "Days");

            migrationBuilder.RenameColumn(
                name: "dayname",
                table: "Days",
                newName: "Dayname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dayname",
                table: "Days",
                newName: "dayname");

            migrationBuilder.AddColumn<string>(
                name: "PosteId",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReposId",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplementId",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
