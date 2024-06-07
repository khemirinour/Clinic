using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Nour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DailyEmployments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndHour",
                table: "DailyEmployments",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "DailyEmployments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartHour",
                table: "DailyEmployments",
                type: "time",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "DailyEmployments");
        }
    }
}
