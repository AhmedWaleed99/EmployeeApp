using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeymanagerid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerID",
                table: "EmployeePenalty",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePenalty_ManagerID",
                table: "EmployeePenalty",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePenalty_AspNetUsers_ManagerID",
                table: "EmployeePenalty",
                column: "ManagerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePenalty_AspNetUsers_ManagerID",
                table: "EmployeePenalty");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePenalty_ManagerID",
                table: "EmployeePenalty");

            migrationBuilder.DropColumn(
                name: "ManagerID",
                table: "EmployeePenalty");
        }
    }
}
