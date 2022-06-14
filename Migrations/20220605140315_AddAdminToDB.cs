using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMAstationeryStore.Migrations
{
    public partial class AddAdminToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminPhone = table.Column<int>(type: "int", nullable: false),
                    adminStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminSector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.adminId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");
        }
    }
}
