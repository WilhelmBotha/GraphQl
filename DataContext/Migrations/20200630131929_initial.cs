using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HealthCheckUri = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    HttpStatus = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "Body", "HealthCheckUri", "HttpStatus", "Name", "Status" },
                values: new object[,]
                {
                    { "1", "", "http://httpstat.us/200", "", "Check 1", "" },
                    { "2", "", "http://httpstat.us/202", "", "Check 2", "" },
                    { "3", "", "http://httpstat.us/400", "", "Check 3", "" },
                    { "4", "", "http://httpstat.us/500", "", "Check 4", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
