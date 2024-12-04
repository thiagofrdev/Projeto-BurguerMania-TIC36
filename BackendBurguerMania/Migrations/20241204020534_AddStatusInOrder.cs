using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendBurguerMania.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status_ID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_ID",
                table: "Orders");
        }
    }
}
