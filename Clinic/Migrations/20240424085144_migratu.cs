using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class migratu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_day",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "PosteId",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "ReposId",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "SupplementId",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "Id_day",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "PosteId",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "ReposId",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "SupplementId",
                table: "DailyEmployments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_day",
                table: "Emplois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosteId",
                table: "Emplois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReposId",
                table: "Emplois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplementId",
                table: "Emplois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_day",
                table: "DailyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosteId",
                table: "DailyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReposId",
                table: "DailyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplementId",
                table: "DailyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
