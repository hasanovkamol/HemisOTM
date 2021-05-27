using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModelEntity.Migrations
{
    public partial class ManyToManyForSubjectAndHarvestPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarvestPlans_Subjects_SubjectId",
                table: "HarvestPlans");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "HarvestPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SubjectTraingPlan",
                columns: table => new
                {
                    SubjectTraingPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    HardvesPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTraingPlan", x => x.SubjectTraingPlanId);
                    table.ForeignKey(
                        name: "FK_SubjectTraingPlan_HarvestPlans_HardvesPlanId",
                        column: x => x.HardvesPlanId,
                        principalTable: "HarvestPlans",
                        principalColumn: "HarvestPlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTraingPlan_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlan_HardvesPlanId",
                table: "SubjectTraingPlan",
                column: "HardvesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlan_SubjectId",
                table: "SubjectTraingPlan",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestPlans_Subjects_SubjectId",
                table: "HarvestPlans",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarvestPlans_Subjects_SubjectId",
                table: "HarvestPlans");

            migrationBuilder.DropTable(
                name: "SubjectTraingPlan");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "HarvestPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestPlans_Subjects_SubjectId",
                table: "HarvestPlans",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
