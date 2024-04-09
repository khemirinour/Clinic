using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class Data : Migration
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
                name: "GestionViewModels",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    NouveauPoste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NouveauRepos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NouveauSupplement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    HRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HRName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.HRId);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyEmployments",
                columns: table => new
                {
                    WeeklyEmploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyEmployments", x => x.WeeklyEmploymentId);
                });

            migrationBuilder.CreateTable(
                name: "ChefsDeService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefDeServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefsDeService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyEmployments",
                columns: table => new
                {
                    DailyEmploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WeeklyEmploymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEmployments", x => x.DailyEmploymentId);
                    table.ForeignKey(
                        name: "FK_DailyEmployments_WeeklyEmployments_WeeklyEmploymentId",
                        column: x => x.WeeklyEmploymentId,
                        principalTable: "WeeklyEmployments",
                        principalColumn: "WeeklyEmploymentId");
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emplois",
                columns: table => new
                {
                    EmploiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    TotalWeeklyHours = table.Column<int>(type: "int", nullable: false),
                    DayCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: true),
                    HRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplois", x => x.EmploiId);
                    table.ForeignKey(
                        name: "FK_Emplois_ChefsDeService_ChefDeServiceId",
                        column: x => x.ChefDeServiceId,
                        principalTable: "ChefsDeService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emplois_HR_HRId",
                        column: x => x.HRId,
                        principalTable: "HR",
                        principalColumn: "HRId");
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
                    PositionY = table.Column<int>(type: "int", nullable: true),
                    DailyEmploymentId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Postes_DailyEmployments_DailyEmploymentId",
                        column: x => x.DailyEmploymentId,
                        principalTable: "DailyEmployments",
                        principalColumn: "DailyEmploymentId");
                    table.ForeignKey(
                        name: "FK_Postes_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                });

            migrationBuilder.CreateTable(
                name: "Repos",
                columns: table => new
                {
                    ReposId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReposName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Jours = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Joursfin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true),
                    DailyEmploymentId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Repos_DailyEmployments_DailyEmploymentId",
                        column: x => x.DailyEmploymentId,
                        principalTable: "DailyEmployments",
                        principalColumn: "DailyEmploymentId");
                    table.ForeignKey(
                        name: "FK_Repos_Emplois_EmploiId",
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
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChefDeService = table.Column<bool>(type: "bit", nullable: true),
                    TotalWeeklyHours = table.Column<int>(type: "int", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Employee_Emplois_EmploiId",
                        column: x => x.EmploiId,
                        principalTable: "Emplois",
                        principalColumn: "EmploiId");
                    table.ForeignKey(
                        name: "FK_Employee_Postes_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Postes",
                        principalColumn: "PosteId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePoste",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePoste", x => new { x.EmployeeId, x.PosteId });
                    table.ForeignKey(
                        name: "FK_EmployeePoste_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePoste_Postes_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Postes",
                        principalColumn: "PosteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRepos",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReposId = table.Column<int>(type: "int", nullable: false),
                    ReposId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRepos", x => new { x.EmployeeId, x.ReposId });
                    table.ForeignKey(
                        name: "FK_EmployeeRepos_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRepos_Repos_ReposId",
                        column: x => x.ReposId,
                        principalTable: "Repos",
                        principalColumn: "ReposId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRepos_Repos_ReposId1",
                        column: x => x.ReposId1,
                        principalTable: "Repos",
                        principalColumn: "ReposId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChefDeServiceId = table.Column<int>(type: "int", nullable: true),
                    ChefDeServiceId1 = table.Column<int>(type: "int", nullable: true),
                    HRId = table.Column<int>(type: "int", nullable: true),
                    ChefServiceId = table.Column<int>(type: "int", nullable: true),
                    ChefServiceEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_ChefsDeService_ChefDeServiceId1",
                        column: x => x.ChefDeServiceId1,
                        principalTable: "ChefsDeService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Employee_ChefServiceEmployeeId",
                        column: x => x.ChefServiceEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Services_HR_HRId",
                        column: x => x.HRId,
                        principalTable: "HR",
                        principalColumn: "HRId");
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    SupplementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmploiId = table.Column<int>(type: "int", nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: true),
                    PositionY = table.Column<int>(type: "int", nullable: true),
                    DailyEmploymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.SupplementId);
                    table.ForeignKey(
                        name: "FK_Supplements_DailyEmployments_DailyEmploymentId",
                        column: x => x.DailyEmploymentId,
                        principalTable: "DailyEmployments",
                        principalColumn: "DailyEmploymentId");
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
                name: "EmployeeSupplements",
                columns: table => new
                {
                    EmployeeSupplementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SupplementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSupplements", x => x.EmployeeSupplementId);
                    table.ForeignKey(
                        name: "FK_EmployeeSupplements_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSupplements_Supplements_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplements",
                        principalColumn: "SupplementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefsDeService_EmployeeId",
                table: "ChefsDeService",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefsDeService_ServiceId",
                table: "ChefsDeService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_EmployeeId",
                table: "DailyEmployments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEmployments_WeeklyEmploymentId",
                table: "DailyEmployments",
                column: "WeeklyEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_EmploiId",
                table: "Days",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_ChefDeServiceId",
                table: "Emplois",
                column: "ChefDeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_HRId",
                table: "Emplois",
                column: "HRId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_ServiceId",
                table: "Emplois",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CategorieId",
                table: "Employee",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploiId",
                table: "Employee",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PosteId",
                table: "Employee",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ServiceId",
                table: "Employee",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePoste_PosteId",
                table: "EmployeePoste",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRepos_ReposId",
                table: "EmployeeRepos",
                column: "ReposId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRepos_ReposId1",
                table: "EmployeeRepos",
                column: "ReposId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSupplements_EmployeeId",
                table: "EmployeeSupplements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSupplements_SupplementId",
                table: "EmployeeSupplements",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_CategorieId",
                table: "Postes",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_DailyEmploymentId",
                table: "Postes",
                column: "DailyEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_EmploiId",
                table: "Postes",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_CategorieId",
                table: "Repos",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_DailyEmploymentId",
                table: "Repos",
                column: "DailyEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Repos_EmploiId",
                table: "Repos",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ChefDeServiceId1",
                table: "Services",
                column: "ChefDeServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ChefServiceEmployeeId",
                table: "Services",
                column: "ChefServiceEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HRId",
                table: "Services",
                column: "HRId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_DailyEmploymentId",
                table: "Supplements",
                column: "DailyEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_EmploiId",
                table: "Supplements",
                column: "EmploiId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_EmployeeId",
                table: "Supplements",
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
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyEmployments_Employee_EmployeeId",
                table: "DailyEmployments",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Emplois_EmploiId",
                table: "Days",
                column: "EmploiId",
                principalTable: "Emplois",
                principalColumn: "EmploiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emplois_Services_ServiceId",
                table: "Emplois",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Services_ServiceId",
                table: "Employee",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefsDeService_Employee_EmployeeId",
                table: "ChefsDeService");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyEmployments_Employee_EmployeeId",
                table: "DailyEmployments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Employee_ChefServiceEmployeeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ChefsDeService_Services_ServiceId",
                table: "ChefsDeService");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "EmployeePoste");

            migrationBuilder.DropTable(
                name: "EmployeeRepos");

            migrationBuilder.DropTable(
                name: "EmployeeSupplements");

            migrationBuilder.DropTable(
                name: "GestionViewModels");

            migrationBuilder.DropTable(
                name: "Repos");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Postes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DailyEmployments");

            migrationBuilder.DropTable(
                name: "Emplois");

            migrationBuilder.DropTable(
                name: "WeeklyEmployments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ChefsDeService");

            migrationBuilder.DropTable(
                name: "HR");
        }
    }
}
