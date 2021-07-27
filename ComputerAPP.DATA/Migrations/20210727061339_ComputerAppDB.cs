using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerAPP.DATA.Migrations
{
    public partial class ComputerAppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    DesktopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SsdCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HddCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Psu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.DesktopId);
                });

            migrationBuilder.CreateTable(
                name: "NoteBooks",
                columns: table => new
                {
                    NoteBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SsdCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HddCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Battery = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteBooks", x => x.NoteBookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "NoteBooks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
