using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Infrastructure.Migrations
{
    public partial class Discriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "NVARCHAR(18)", maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Cnpj);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "NVARCHAR(18)", maxLength: 18, nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCities",
                columns: table => new
                {
                    CompanyCnpj = table.Column<string>(type: "NVARCHAR(18)", nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCities", x => new { x.CompanyCnpj, x.CityId });
                    table.ForeignKey(
                        name: "FK_CompanyCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCities_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeDate = table.Column<int>(type: "int", nullable: false),
                    MakedDate = table.Column<int>(type: "int", nullable: false),
                    KilometersTraveled = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AcceptsChange = table.Column<bool>(type: "bit", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsLicensed = table.Column<bool>(type: "bit", nullable: false),
                    IsArmored = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfExchange = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    GasolineType = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "NVARCHAR(18)", nullable: true),
                    CityId = table.Column<int>(type: "INT", nullable: false),
                    NumberOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Plate);
                    table.ForeignKey(
                        name: "FK_Cars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Companies_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Users_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "NVARCHAR(18)", nullable: true),
                    Time = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Companies_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logins_Users_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    Discriminator = table.Column<string>(type: "NVARCHAR(18)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Companies_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Users_Discriminator",
                        column: x => x.Discriminator,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageStream = table.Column<string>(type: "NVARCHAR", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Cars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarPlate",
                table: "CarImages",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Discriminator",
                table: "Cars",
                column: "Discriminator");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCities_CityId",
                table: "CompanyCities",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities",
                column: "CompanyCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Discriminator",
                table: "Logins",
                column: "Discriminator");

            migrationBuilder.CreateIndex(
                name: "IX_News_Discriminator",
                table: "News",
                column: "Discriminator");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "CompanyCities");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
