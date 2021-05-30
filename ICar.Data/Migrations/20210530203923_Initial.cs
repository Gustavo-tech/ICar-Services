using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "CHAR(18)", nullable: false),
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    CompanyCnpj = table.Column<string>(type: "CHAR(18)", nullable: true),
                    CompanyCnpj1 = table.Column<string>(type: "CHAR(18)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Companies_CompanyCnpj1",
                        column: x => x.CompanyCnpj1,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCnpj = table.Column<string>(type: "CHAR(18)", nullable: true),
                    CompanyCnpj1 = table.Column<string>(type: "CHAR(18)", nullable: true),
                    Time = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLogins_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLogins_Companies_CompanyCnpj1",
                        column: x => x.CompanyCnpj1,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCnpj = table.Column<string>(type: "CHAR(18)", nullable: true),
                    PublishedByCnpj = table.Column<string>(type: "CHAR(18)", nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyNews_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyNews_Companies_PublishedByCnpj",
                        column: x => x.PublishedByCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCars",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "Char(8)", nullable: false),
                    CompanyCnpj = table.Column<string>(type: "CHAR(18)", nullable: true),
                    CompanyCnpj1 = table.Column<string>(type: "CHAR(18)", nullable: true),
                    Maker = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    MakeDate = table.Column<int>(type: "INT", nullable: false),
                    MakedDate = table.Column<int>(type: "INT", nullable: false),
                    KilometersTraveled = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(38,17)", maxLength: 10000000, nullable: false),
                    AcceptsChange = table.Column<bool>(type: "BIT", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "BIT", nullable: false),
                    IsLicensed = table.Column<bool>(type: "BIT", nullable: false),
                    IsArmored = table.Column<bool>(type: "BIT", nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    TypeOfExchange = table.Column<string>(type: "CHAR(3)", nullable: false),
                    Color = table.Column<int>(type: "INT", maxLength: 3, nullable: false),
                    GasolineType = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false),
                    CityId1 = table.Column<int>(type: "INT", nullable: true),
                    NumberOfViews = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCars", x => x.Plate);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Companies_CompanyCnpj1",
                        column: x => x.CompanyCnpj1,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCities",
                columns: table => new
                {
                    CompanyCnpj = table.Column<string>(type: "CHAR(18)", nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCities", x => new { x.CityId, x.CompanyCnpj });
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
                name: "Users",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false),
                    CityId1 = table.Column<int>(type: "INT", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "Char(8)", nullable: false),
                    UserCpf = table.Column<string>(type: "CHAR(14)", nullable: true),
                    UserCpf1 = table.Column<string>(type: "CHAR(14)", nullable: true),
                    Maker = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    MakeDate = table.Column<int>(type: "INT", nullable: false),
                    MakedDate = table.Column<int>(type: "INT", nullable: false),
                    KilometersTraveled = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(38,17)", maxLength: 10000000, nullable: false),
                    AcceptsChange = table.Column<bool>(type: "BIT", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "BIT", nullable: false),
                    IsLicensed = table.Column<bool>(type: "BIT", nullable: false),
                    IsArmored = table.Column<bool>(type: "BIT", nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    TypeOfExchange = table.Column<string>(type: "CHAR(3)", nullable: false),
                    Color = table.Column<int>(type: "INT", maxLength: 3, nullable: false),
                    GasolineType = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    CityId = table.Column<int>(type: "INT", nullable: false),
                    CityId1 = table.Column<int>(type: "INT", nullable: true),
                    NumberOfViews = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => x.Plate);
                    table.ForeignKey(
                        name: "FK_UserCars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCars_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserCpf",
                        column: x => x.UserCpf,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserCpf1",
                        column: x => x.UserCpf1,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCpf = table.Column<string>(type: "CHAR(14)", nullable: true),
                    UserCpf1 = table.Column<string>(type: "CHAR(14)", nullable: true),
                    Time = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserCpf",
                        column: x => x.UserCpf,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserCpf1",
                        column: x => x.UserCpf1,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCpf = table.Column<string>(type: "CHAR(14)", nullable: true),
                    PublishedByCpf = table.Column<string>(type: "CHAR(14)", nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNews_Users_PublishedByCpf",
                        column: x => x.PublishedByCpf,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNews_Users_UserCpf",
                        column: x => x.UserCpf,
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
                    CarPlate = table.Column<string>(type: "Char(8)", nullable: true),
                    CompanyCarPlate = table.Column<string>(type: "Char(8)", nullable: true),
                    UserCarPlate = table.Column<string>(type: "Char(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_CompanyCars_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "CompanyCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarImages_CompanyCars_CompanyCarPlate",
                        column: x => x.CompanyCarPlate,
                        principalTable: "CompanyCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarImages_UserCars_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "UserCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarImages_UserCars_UserCarPlate",
                        column: x => x.UserCarPlate,
                        principalTable: "UserCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarPlate",
                table: "CarImages",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CompanyCarPlate",
                table: "CarImages",
                column: "CompanyCarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_UserCarPlate",
                table: "CarImages",
                column: "UserCarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj1",
                table: "Cities",
                column: "CompanyCnpj1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CityId",
                table: "CompanyCars",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CityId1",
                table: "CompanyCars",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CompanyCnpj",
                table: "CompanyCars",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CompanyCnpj1",
                table: "CompanyCars",
                column: "CompanyCnpj1");

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
                name: "IX_CompanyLogins_CompanyCnpj",
                table: "CompanyLogins",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogins_CompanyCnpj1",
                table: "CompanyLogins",
                column: "CompanyCnpj1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_CompanyCnpj",
                table: "CompanyNews",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_PublishedByCnpj",
                table: "CompanyNews",
                column: "PublishedByCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CityId",
                table: "UserCars",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CityId1",
                table: "UserCars",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_UserCpf",
                table: "UserCars",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_UserCpf1",
                table: "UserCars",
                column: "UserCpf1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpf",
                table: "UserLogins",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpf1",
                table: "UserLogins",
                column: "UserCpf1");

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_PublishedByCpf",
                table: "UserNews",
                column: "PublishedByCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_UserCpf",
                table: "UserNews",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId1",
                table: "Users",
                column: "CityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "CompanyCities");

            migrationBuilder.DropTable(
                name: "CompanyLogins");

            migrationBuilder.DropTable(
                name: "CompanyNews");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserNews");

            migrationBuilder.DropTable(
                name: "CompanyCars");

            migrationBuilder.DropTable(
                name: "UserCars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
