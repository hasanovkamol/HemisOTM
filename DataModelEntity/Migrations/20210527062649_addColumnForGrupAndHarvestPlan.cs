using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModelEntity.Migrations
{
    public partial class addColumnForGrupAndHarvestPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depatment",
                table: "HarvestPlans");

            migrationBuilder.AddColumn<int>(
                name: "DepatmentId",
                table: "HarvestPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GetDepartmentDepartmentId",
                table: "HarvestPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPranet",
                table: "Grups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_GetDepartmentDepartmentId",
                table: "HarvestPlans",
                column: "GetDepartmentDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HarvestPlans_Departments_GetDepartmentDepartmentId",
                table: "HarvestPlans",
                column: "GetDepartmentDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarvestPlans_Departments_GetDepartmentDepartmentId",
                table: "HarvestPlans");

            migrationBuilder.DropIndex(
                name: "IX_HarvestPlans_GetDepartmentDepartmentId",
                table: "HarvestPlans");

            migrationBuilder.DropColumn(
                name: "DepatmentId",
                table: "HarvestPlans");

            migrationBuilder.DropColumn(
                name: "GetDepartmentDepartmentId",
                table: "HarvestPlans");

            migrationBuilder.DropColumn(
                name: "isPranet",
                table: "Grups");

            migrationBuilder.AddColumn<string>(
                name: "Depatment",
                table: "HarvestPlans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
