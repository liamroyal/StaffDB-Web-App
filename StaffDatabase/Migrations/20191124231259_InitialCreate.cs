using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    IrdNo = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Mname = table.Column<string>(nullable: true),
                    HomePh = table.Column<int>(nullable: false),
                    CellPh = table.Column<int>(nullable: false),
                    OffExtension = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.IrdNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffMember");
        }
    }
}
