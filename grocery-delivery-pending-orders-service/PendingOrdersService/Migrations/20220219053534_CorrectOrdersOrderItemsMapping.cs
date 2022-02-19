using Microsoft.EntityFrameworkCore.Migrations;

namespace PendingOrdersService.Migrations
{
    public partial class CorrectOrdersOrderItemsMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_status",
                table: "orderitems");

            migrationBuilder.DropColumn(
                name: "total",
                table: "orderitems");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "orders",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "orderitems",
                newName: "quantity");

            migrationBuilder.AddColumn<string>(
                name: "order_status",
                table: "orders",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orderitems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_status",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "total",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "orderitems");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "orders",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "orderitems",
                newName: "customer_id");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "order_status",
                table: "orderitems",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "orderitems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
