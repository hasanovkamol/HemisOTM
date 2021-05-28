using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModelEntity.Migrations
{
    public partial class UpdateDatabaseForSubjectTring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTraingPlan_HarvestPlans_HardvesPlanId",
                table: "SubjectTraingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTraingPlan_Subjects_SubjectId",
                table: "SubjectTraingPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTraingPlan",
                table: "SubjectTraingPlan");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTraingPlan_HardvesPlanId",
                table: "SubjectTraingPlan");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTraingPlan_SubjectId",
                table: "SubjectTraingPlan");

            migrationBuilder.DropColumn(
                name: "HardvesPlanId",
                table: "SubjectTraingPlan");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectTraingPlan");

            migrationBuilder.RenameTable(
                name: "SubjectTraingPlan",
                newName: "SubjectTraingPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTraingPlans",
                table: "SubjectTraingPlans",
                column: "SubjectTraingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlans_GetHardvesPlanId",
                table: "SubjectTraingPlans",
                column: "GetHardvesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlans_GetSubjectId",
                table: "SubjectTraingPlans",
                column: "GetSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTraingPlans_HarvestPlans_GetHardvesPlanId",
                table: "SubjectTraingPlans",
                column: "GetHardvesPlanId",
                principalTable: "HarvestPlans",
                principalColumn: "HarvestPlanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTraingPlans_Subjects_GetSubjectId",
                table: "SubjectTraingPlans",
                column: "GetSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTraingPlans_HarvestPlans_GetHardvesPlanId",
                table: "SubjectTraingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTraingPlans_Subjects_GetSubjectId",
                table: "SubjectTraingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTraingPlans",
                table: "SubjectTraingPlans");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTraingPlans_GetHardvesPlanId",
                table: "SubjectTraingPlans");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTraingPlans_GetSubjectId",
                table: "SubjectTraingPlans");

            migrationBuilder.RenameTable(
                name: "SubjectTraingPlans",
                newName: "SubjectTraingPlan");

            migrationBuilder.AddColumn<int>(
                name: "HardvesPlanId",
                table: "SubjectTraingPlan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectTraingPlan",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTraingPlan",
                table: "SubjectTraingPlan",
                column: "SubjectTraingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlan_HardvesPlanId",
                table: "SubjectTraingPlan",
                column: "HardvesPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTraingPlan_SubjectId",
                table: "SubjectTraingPlan",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTraingPlan_HarvestPlans_HardvesPlanId",
                table: "SubjectTraingPlan",
                column: "HardvesPlanId",
                principalTable: "HarvestPlans",
                principalColumn: "HarvestPlanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTraingPlan_Subjects_SubjectId",
                table: "SubjectTraingPlan",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
