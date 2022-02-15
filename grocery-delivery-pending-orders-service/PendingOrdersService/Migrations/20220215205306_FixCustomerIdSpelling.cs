using Microsoft.EntityFrameworkCore.Migrations;

namespace PendingOrdersService.Migrations
{
    public partial class FixCustomerIdSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customre_id",
                table: "orderitems",
                newName: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "orderitems",
                newName: "customre_id");
        }
    }
}
