using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBurguerMania.Migrations
{
    /// <inheritdoc />
    public partial class RequiredProductFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_ID",
                table: "Products",
                column: "Category_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Category_ID",
                table: "Products",
                column: "Category_ID",
                principalTable: "Categories",
                principalColumn: "ID_Category",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Category_ID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Category_ID",
                table: "Products");
        }
    }
}
