using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Migration1278 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Emplois");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Days",
                newName: "Id_day");

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

            migrationBuilder.AlterColumn<string>(
                name: "Service",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateofWeek",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Categorie",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Id_day",
                table: "Days",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Emplois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Emplois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Service",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateofWeek",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categorie",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
