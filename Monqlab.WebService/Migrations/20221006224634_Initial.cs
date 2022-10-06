using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monqlab.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 1000, nullable: true),
                    Body = table.Column<string>(nullable: false),
                    CreationDateUtc = table.Column<DateTime>(nullable: false),
                    Result = table.Column<string>(maxLength: 10, nullable: true),
                    FailedMessage = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMessages");
        }
    }
}
