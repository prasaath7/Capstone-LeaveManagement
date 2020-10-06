using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AvailableLeavescreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "PaidLeave",
                table: "Users",
                nullable: false,
                defaultValue: 20);

            migrationBuilder.AddColumn<int>(
                name: "UnpaidLeave",
                table: "Users",
                nullable: false,
                defaultValue: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidLeave",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UnpaidLeave",
                table: "Users");

           
        }
    }
}
