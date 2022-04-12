using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkLabb.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Applications_LeaveApplicationApplicationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LeaveApplicationApplicationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeaveApplicationApplicationId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_EmployeId",
                table: "Applications",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Employees_EmployeId",
                table: "Applications",
                column: "EmployeId",
                principalTable: "Employees",
                principalColumn: "EmployeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Employees_EmployeId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_EmployeId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "LeaveApplicationApplicationId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LeaveApplicationApplicationId",
                table: "Employees",
                column: "LeaveApplicationApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Applications_LeaveApplicationApplicationId",
                table: "Employees",
                column: "LeaveApplicationApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
