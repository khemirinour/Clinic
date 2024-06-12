using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "PositionY",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "PositionY",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "hFin",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "hdebut",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "Postes");

            migrationBuilder.DropColumn(
                name: "PositionY",
                table: "Postes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Supplements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Supplements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndHour",
                table: "Supplements",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Supplements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionX",
                table: "Supplements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionY",
                table: "Supplements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartHour",
                table: "Supplements",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionX",
                table: "Repos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionY",
                table: "Repos",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "PositionX",
                table: "Postes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionY",
                table: "Postes",
                type: "int",
                nullable: true);
        }
    }
}
