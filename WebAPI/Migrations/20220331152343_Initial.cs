using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InverterSn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcPower = table.Column<float>(type: "real", nullable: true),
                    YieldToday = table.Column<float>(type: "real", nullable: true),
                    YieldTotal = table.Column<float>(type: "real", nullable: true),
                    FeedInPower = table.Column<float>(type: "real", nullable: true),
                    FeedInEnergy = table.Column<float>(type: "real", nullable: true),
                    ConsumedEnergy = table.Column<float>(type: "real", nullable: true),
                    InverterType = table.Column<int>(type: "int", nullable: true),
                    InverterStatus = table.Column<int>(type: "int", nullable: true),
                    UploadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PowerDc1 = table.Column<float>(type: "real", nullable: true),
                    PowerDc2 = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solax", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solax");
        }
    }
}
