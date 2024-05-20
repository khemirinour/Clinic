using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class mig148 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefsDeService_Employee_EmployeeId",
                table: "ChefsDeService");

            migrationBuilder.DropForeignKey(
                name: "FK_ChefsDeService_Services_ServiceId",
                table: "ChefsDeService");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplois_ChefsDeService_ChefDeServiceId",
                table: "Emplois");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefsDeService",
                table: "ChefsDeService");

            migrationBuilder.DropIndex(
                name: "IX_ChefsDeService_EmployeeId",
                table: "ChefsDeService");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ChefsDeService");

            migrationBuilder.RenameTable(
                name: "ChefsDeService",
                newName: "ChefDeService");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChefDeService",
                newName: "ChefDeServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ChefsDeService_ServiceId",
                table: "ChefDeService",
                newName: "IX_ChefDeService_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "ChefDeServiceId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ChefDeServiceId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ChefDeService",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefDeService",
                table: "ChefDeService",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ChefDeServiceId",
                table: "Services",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ChefDeServiceId",
                table: "Employee",
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
                name: "FK_Services_ChefDeService_ChefDeServiceId",
                table: "Services",
                column: "ChefDeServiceId",
                principalTable: "ChefDeService",
                principalColumn: "ChefDeServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Services_ChefDeService_ChefDeServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ChefDeServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ChefDeServiceId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefDeService",
                table: "ChefDeService");

            migrationBuilder.DropColumn(
                name: "ChefDeServiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ChefDeServiceId",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "ChefDeService",
                newName: "ChefsDeService");

            migrationBuilder.RenameColumn(
                name: "ChefDeServiceId",
                table: "ChefsDeService",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChefDeService_ServiceId",
                table: "ChefsDeService",
                newName: "IX_ChefsDeService_ServiceId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ChefsDeService",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ChefsDeService",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefsDeService",
                table: "ChefsDeService",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChefsDeService_EmployeeId",
                table: "ChefsDeService",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefsDeService_Employee_EmployeeId",
                table: "ChefsDeService",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefsDeService_Services_ServiceId",
                table: "ChefsDeService",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emplois_ChefsDeService_ChefDeServiceId",
                table: "Emplois",
                column: "ChefDeServiceId",
                principalTable: "ChefsDeService",
                principalColumn: "Id");
        }
    }
}
