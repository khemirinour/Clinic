using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "ChefDeServices",
                columns: table => new
                {
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefDeServices", x => x.ChefDeServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ChefDeServices_ChefDeServiceId",
                        column: x => x.ChefDeServiceId,
                        principalTable: "ChefDeServices",
                        principalColumn: "ChefDeServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Emplois",
                columns: table => new
                {
                    EmploiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfWeek = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceSelected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieSelected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplois", x => x.EmploiId);
                    table.ForeignKey(
                        name: "FK_Emplois_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                    table.ForeignKey(
                        name: "FK_Emplois_ChefDeServices_ChefDeServiceId",
                        column: x => x.ChefDeServiceId,
                        principalTable: "ChefDeServices",
                        principalColumn: "ChefDeServiceId");
                    table.ForeignKey(
                        name: "FK_Emplois_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id_day = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id_day);
                    table.ForeignKey(
                        name: "FK_Days_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChefDeService = table.Column<bool>(type: "bit", nullable: true),
                    TotalWeeklyHours = table.Column<int>(type: "int", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                    table.ForeignKey(
                        name: "FK_Employee_ChefDeServices_ChefDeServiceId",
                        column: x => x.ChefDeServiceId,
                        principalTable: "ChefDeServices",
                        principalColumn: "ChefDeServiceId");
                    table.ForeignKey(
                        name: "FK_Employee_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                    table.ForeignKey(
                        name: "FK_Employee_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postes",
                columns: table => new
                {
                    PosteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matin = table.Column<bool>(type: "bit", nullable: false),
                    ApresMidi = table.Column<bool>(type: "bit", nullable: false),
                    GardeSoir = table.Column<bool>(type: "bit", nullable: false),
                    Seance1Debut = table.Column<TimeSpan>(type: "time", nullable: false),
                    Seance1Fin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Seance2Debut = table.Column<TimeSpan>(type: "time", nullable: true),
                    Seance2Fin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postes", x => x.PosteId);
                    table.ForeignKey(
                        name: "FK_Postes_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postes_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                });

            migrationBuilder.CreateTable(
                name: "DailyEmployments",
                columns: table => new
                {
                    DailyEmploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfWeek = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PosteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReposId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: false),
                    EmployeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    DateDuJour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEmployments", x => x.DailyEmploymentId);
                    table.ForeignKey(
                        name: "FK_DailyEmployments_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                    table.ForeignKey(
                        name: "FK_DailyEmployments_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyEmployments_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyEmployments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Repos",
                columns: table => new
                {
                    ReposId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReposName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Jours = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hdebut = table.Column<TimeSpan>(type: "time", nullable: true),
                    hFin = table.Column<TimeSpan>(type: "time", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repos", x => x.ReposId);
                    table.ForeignKey(
                        name: "FK_Repos_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repos_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                    table.ForeignKey(
                        name: "FK_Repos_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    SupplementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.SupplementId);
                    table.ForeignKey(
                        name: "FK_Supplements_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplements_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                    table.ForeignKey(
                        name: "FK_Supplements_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePoste",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    PostesPosteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePoste", x => new { x.EmployeesEmployeeId, x.PostesPosteId });
                    table.ForeignKey(
                        name: "FK_EmployeePoste_Employee_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePoste_Postes_PostesPosteId",
                        column: x => x.PostesPosteId,
                        principalTable: "Postes",
                        principalColumn: "PosteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefDeServices_ServiceId",
                table: "ChefDeServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_CategorieId",
                table: "DailyEmployments",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_EmploiId",
                table: "DailyEmployments",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_EmployeeId",
                table: "DailyEmployments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_ServiceId",
                table: "DailyEmployments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_EmploiId",
                table: "Days",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_CategorieId",
                table: "Emplois",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_ChefDeServiceId",
                table: "Emplois",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_ServiceId",
                table: "Emplois",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CategorieId",
                table: "Employee",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ChefDeServiceId",
                table: "Employee",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploiId",
                table: "Employee",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ServiceId",
                table: "Employee",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePoste_PostesPosteId",
                table: "EmployeePoste",
                column: "PostesPosteId");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_CategorieId",
                table: "Postes",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_EmploiId",
                table: "Postes",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_CategorieId",
                table: "Repos",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_EmploiId",
                table: "Repos",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_EmployeeId",
                table: "Repos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ChefDeServiceId",
                table: "Services",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_CategorieId",
                table: "Supplements",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_EmploiId",
                table: "Supplements",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_EmployeeId",
                table: "Supplements",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefDeServices_Services_ServiceId",
                table: "ChefDeServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefDeServices_Services_ServiceId",
                table: "ChefDeServices");

            migrationBuilder.DropTable(
                name: "DailyEmployments");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "EmployeePoste");

            migrationBuilder.DropTable(
                name: "Repos");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.DropTable(
                name: "Postes");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Emplois");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ChefDeServices");
        }
    }
}
