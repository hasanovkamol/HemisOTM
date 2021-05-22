using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModelEntity.Migrations
{
    public partial class SubjectGrupBlockTypeHarvestPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grups",
                columns: table => new
                {
                    GrupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grups", x => x.GrupId);
                    table.ForeignKey(
                        name: "FK_Grups_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectBlockTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectBlockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Practical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seminar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndependentEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountofCredit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "HarvestPlans",
                columns: table => new
                {
                    HarvestPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GrupId = table.Column<int>(type: "int", nullable: false),
                    BlockTypeId = table.Column<int>(type: "int", nullable: false),
                    SubjectBlockTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestPlans", x => x.HarvestPlanId);
                    table.ForeignKey(
                        name: "FK_HarvestPlans_Grups_GrupId",
                        column: x => x.GrupId,
                        principalTable: "Grups",
                        principalColumn: "GrupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestPlans_SubjectBlockTypes_SubjectBlockTypeId",
                        column: x => x.SubjectBlockTypeId,
                        principalTable: "SubjectBlockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HarvestPlans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestPlans_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grups_StudentId",
                table: "Grups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_GrupId",
                table: "HarvestPlans",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_SubjectBlockTypeId",
                table: "HarvestPlans",
                column: "SubjectBlockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_SubjectId",
                table: "HarvestPlans",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_TeacherId",
                table: "HarvestPlans",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarvestPlans");

            migrationBuilder.DropTable(
                name: "Grups");

            migrationBuilder.DropTable(
                name: "SubjectBlockTypes");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
