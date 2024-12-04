using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBurguerMania.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersProductsAtOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID_User",
                table: "UsersOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_Order_ID",
                table: "UsersOrders",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_UserID_User",
                table: "UsersOrders",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_Order_ID",
                table: "OrdersProducts",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_Product_ID",
                table: "OrdersProducts",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status_ID",
                table: "Orders",
                column: "Status_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_Status_ID",
                table: "Orders",
                column: "Status_ID",
                principalTable: "Statuses",
                principalColumn: "ID_Status",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_Order_ID",
                table: "OrdersProducts",
                column: "Order_ID",
                principalTable: "Orders",
                principalColumn: "ID_Order",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_Product_ID",
                table: "OrdersProducts",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "ID_Product",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersOrders_Orders_Order_ID",
                table: "UsersOrders",
                column: "Order_ID",
                principalTable: "Orders",
                principalColumn: "ID_Order",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersOrders_Users_UserID_User",
                table: "UsersOrders",
                column: "UserID_User",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_Status_ID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Orders_Order_ID",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_Product_ID",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersOrders_Orders_Order_ID",
                table: "UsersOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersOrders_Users_UserID_User",
                table: "UsersOrders");

            migrationBuilder.DropIndex(
                name: "IX_UsersOrders_Order_ID",
                table: "UsersOrders");

            migrationBuilder.DropIndex(
                name: "IX_UsersOrders_UserID_User",
                table: "UsersOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_Order_ID",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_Product_ID",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Status_ID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserID_User",
                table: "UsersOrders");
        }
    }
}
