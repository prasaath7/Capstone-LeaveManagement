using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class LeaveRequestUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LeaveApproved",
                table: "LeaveRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveApproved",
                table: "LeaveRequests");
        }
    }
}
