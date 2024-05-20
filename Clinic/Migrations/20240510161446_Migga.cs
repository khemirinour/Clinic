using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Migga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefDeService_Services_ServiceId",
                table: "ChefDeService");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplois_ChefDeService_ChefDeServiceId",
                table: "Emplois");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ChefDeService_ChefDeServiceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Services_ServiceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ChefDeService_ChefDeServiceId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefDeService",
                table: "ChefDeService");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "ChefDeService",
                newName: "ChefDeServices");

            migrationBuilder.RenameColumn(
                name: "ChefDeServiceName",
                table: "ChefDeServices",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_ChefDeService_ServiceId",
                table: "ChefDeServices",
                newName: "IX_ChefDeServices_ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Employee",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefDeServices",
                table: "ChefDeServices",
                column: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefDeServices_Services_ServiceId",
                table: "ChefDeServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emplois_ChefDeServices_ChefDeServiceId",
                table: "Emplois",
                column: "ChefDeServiceId",
                principalTable: "ChefDeServices",
                principalColumn: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ChefDeServices_ChefDeServiceId",
                table: "Employee",
                column: "ChefDeServiceId",
                principalTable: "ChefDeServices",
                principalColumn: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Services_ServiceId",
                table: "Employee",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ChefDeServices_ChefDeServiceId",
                table: "Services",
                column: "ChefDeServiceId",
                principalTable: "ChefDeServices",
                principalColumn: "ChefDeServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefDeServices_Services_ServiceId",
                table: "ChefDeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplois_ChefDeServices_ChefDeServiceId",
                table: "Emplois");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ChefDeServices_ChefDeServiceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Services_ServiceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ChefDeServices_ChefDeServiceId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefDeServices",
                table: "ChefDeServices");

            migrationBuilder.RenameTable(
                name: "ChefDeServices",
                newName: "ChefDeService");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ChefDeService",
                newName: "ChefDeServiceName");

            migrationBuilder.RenameIndex(
                name: "IX_ChefDeServices_ServiceId",
                table: "ChefDeService",
                newName: "IX_ChefDeService_ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefDeService",
                table: "ChefDeService",
                column: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefDeService_Services_ServiceId",
                table: "ChefDeService",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emplois_ChefDeService_ChefDeServiceId",
                table: "Emplois",
                column: "ChefDeServiceId",
                principalTable: "ChefDeService",
                principalColumn: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ChefDeService_ChefDeServiceId",
                table: "Employee",
                column: "ChefDeServiceId",
                principalTable: "ChefDeService",
                principalColumn: "ChefDeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Services_ServiceId",
                table: "Employee",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ChefDeService_ChefDeServiceId",
                table: "Services",
                column: "ChefDeServiceId",
                principalTable: "ChefDeService",
                principalColumn: "ChefDeServiceId");
        }
    }
}
