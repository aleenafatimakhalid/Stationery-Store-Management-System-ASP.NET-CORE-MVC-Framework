using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMAstationeryStore.Migrations
{
    public partial class AddPromotionalOffersToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotional_Offers",
                columns: table => new
                {
                    offerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offerDuration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotional_Offers", x => x.offerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotional_Offers");
        }
    }
}
