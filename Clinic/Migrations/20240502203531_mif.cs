using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class mif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Joursfin",
                table: "Repos");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "hFin",
                table: "Repos",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "hdebut",
                table: "Repos",
                type: "time",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hFin",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "hdebut",
                table: "Repos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Joursfin",
                table: "Repos",
                type: "datetime2",
                nullable: true);
        }
    }
}
