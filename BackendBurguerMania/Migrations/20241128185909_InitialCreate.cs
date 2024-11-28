using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendBurguerMania.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID_Product = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Path_Image_Product = table.Column<string>(type: "text", nullable: false),
                    Price_Product = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Base_Description_Product = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Full_Description_Product = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Category_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID_Product);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_User = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email_User = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Password_Hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
