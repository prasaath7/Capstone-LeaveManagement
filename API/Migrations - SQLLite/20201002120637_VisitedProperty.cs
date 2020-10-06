using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class VisitedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVisited",
                table: "LeaveRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVisited",
                table: "LeaveRequests");
        }
    }
}
