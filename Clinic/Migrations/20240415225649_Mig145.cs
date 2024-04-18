using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Mig145 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyEmployments_Services_ServiceId",
                table: "WeeklyEmployments");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "WeeklyEmployments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyEmployments_Services_ServiceId",
                table: "WeeklyEmployments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyEmployments_Services_ServiceId",
                table: "WeeklyEmployments");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "WeeklyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyEmployments_Services_ServiceId",
                table: "WeeklyEmployments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
