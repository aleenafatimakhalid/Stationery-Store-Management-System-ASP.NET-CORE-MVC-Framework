using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMAstationeryStore.Migrations
{
    public partial class AddStockToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    stockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.stockID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock");
        }
    }
}
