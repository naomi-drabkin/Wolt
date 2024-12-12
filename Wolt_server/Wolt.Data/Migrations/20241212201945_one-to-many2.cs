using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wolt.Data.Migrations
{
    public partial class onetomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_list_companies_BusinessID1",
                table: "orders_list");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_list_customers_CustomerID",
                table: "orders_list");

            migrationBuilder.DropIndex(
                name: "IX_orders_list_BusinessID1",
                table: "orders_list");

            migrationBuilder.DropIndex(
                name: "IX_orders_list_CustomerID",
                table: "orders_list");

            migrationBuilder.DropColumn(
                name: "BusinessID1",
                table: "orders_list");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "orders_list");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "orders_list",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "customers",
                newName: "Floor");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "orders_list",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessID",
                table: "orders_list",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_orders_list_BusinessID",
                table: "orders_list",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_list_CustomerID",
                table: "orders_list",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_list_companies_BusinessID",
                table: "orders_list",
                column: "BusinessID",
                principalTable: "companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_list_customers_CustomerID",
                table: "orders_list",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_list_companies_BusinessID",
                table: "orders_list");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_list_customers_CustomerID",
                table: "orders_list");

            migrationBuilder.DropIndex(
                name: "IX_orders_list_BusinessID",
                table: "orders_list");

            migrationBuilder.DropIndex(
                name: "IX_orders_list_CustomerID",
                table: "orders_list");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "orders_list",
                newName: "customerID");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "customers",
                newName: "floor");

            migrationBuilder.AlterColumn<int>(
                name: "customerID",
                table: "orders_list",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessID",
                table: "orders_list",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BusinessID1",
                table: "orders_list",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "orders_list",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_orders_list_BusinessID1",
                table: "orders_list",
                column: "BusinessID1");

            migrationBuilder.CreateIndex(
                name: "IX_orders_list_CustomerID",
                table: "orders_list",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_list_companies_BusinessID1",
                table: "orders_list",
                column: "BusinessID1",
                principalTable: "companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_list_customers_CustomerID",
                table: "orders_list",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
