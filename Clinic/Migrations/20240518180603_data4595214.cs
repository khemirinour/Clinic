using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class data4595214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_CategorieId",
                table: "DailyEmployments",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_ServiceId",
                table: "DailyEmployments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyEmployments_Categories_CategorieId",
                table: "DailyEmployments",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyEmployments_Services_ServiceId",
                table: "DailyEmployments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyEmployments_Categories_CategorieId",
                table: "DailyEmployments");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyEmployments_Services_ServiceId",
                table: "DailyEmployments");

            migrationBuilder.DropIndex(
                name: "IX_DailyEmployments_CategorieId",
                table: "DailyEmployments");

            migrationBuilder.DropIndex(
                name: "IX_DailyEmployments_ServiceId",
                table: "DailyEmployments");
        }
    }
}
