using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Supp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "DailyEmployments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_CategorieId",
                table: "Supplements",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplements_Categories_CategorieId",
                table: "Supplements",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplements_Categories_CategorieId",
                table: "Supplements");

            migrationBuilder.DropIndex(
                name: "IX_Supplements_CategorieId",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "DailyEmployments");
        }
    }
}
