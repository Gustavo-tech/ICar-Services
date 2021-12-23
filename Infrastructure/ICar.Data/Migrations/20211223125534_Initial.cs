using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(8)", nullable: true),
                    Location = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    District = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Street = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR", nullable: false),
                    FromUser = table.Column<string>(type: "CHAR(36)", nullable: false),
                    ToUser = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    AuthorId = table.Column<string>(type: "CHAR(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Plate = table.Column<string>(type: "Char(8)", nullable: true),
                    Maker = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    MakeDate = table.Column<int>(type: "INT", nullable: false),
                    MakedDate = table.Column<int>(type: "INT", nullable: false),
                    KilometersTraveled = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "INT", maxLength: 10000000, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    Color = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    NumberOfViews = table.Column<int>(type: "INT", nullable: false),
                    AcceptsChange = table.Column<bool>(type: "bit", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsLicensed = table.Column<bool>(type: "bit", nullable: false),
                    IsArmored = table.Column<bool>(type: "bit", nullable: false),
                    ExchangeType = table.Column<int>(type: "int", nullable: false),
                    GasolineType = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OwnerId = table.Column<string>(type: "CHAR(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarPicture",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<string>(type: "VARCHAR(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPicture_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPicture_CarId",
                table: "CarPicture",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AddressId",
                table: "Cars",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPicture");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
