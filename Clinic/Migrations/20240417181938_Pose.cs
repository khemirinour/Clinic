using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Pose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Emplois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploiId",
                table: "DailyEmployments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_EmploiId",
                table: "DailyEmployments",
                column: "EmploiId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyEmployments_Emplois_EmploiId",
                table: "DailyEmployments",
                column: "EmploiId",
                principalTable: "Emplois",
                principalColumn: "EmploiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyEmployments_Emplois_EmploiId",
                table: "DailyEmployments");

            migrationBuilder.DropIndex(
                name: "IX_DailyEmployments_EmploiId",
                table: "DailyEmployments");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Emplois");

            migrationBuilder.DropColumn(
                name: "EmploiId",
                table: "DailyEmployments");
        }
    }
}
