using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Cnpj);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "CompanyLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "CompanyNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishedByCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyNews", x => x.Id);
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
                    Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Maker = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MakeDate = table.Column<int>(type: "int", nullable: false),
                    MakedDate = table.Column<int>(type: "int", nullable: false),
                    KilometersTraveled = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AcceptsChange = table.Column<bool>(type: "bit", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsLicensed = table.Column<bool>(type: "bit", nullable: false),
                    IsArmored = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TypeOfExchange = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    GasolineType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    NumberOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCars", x => x.Plate);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCars_Companies_CompanyCnpj",
                        column: x => x.CompanyCnpj,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Maker = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MakeDate = table.Column<int>(type: "int", nullable: false),
                    MakedDate = table.Column<int>(type: "int", nullable: false),
                    KilometersTraveled = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AcceptsChange = table.Column<bool>(type: "bit", nullable: false),
                    IpvaIsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsLicensed = table.Column<bool>(type: "bit", nullable: false),
                    IsArmored = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TypeOfExchange = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    GasolineType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    NumberOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => x.Plate);
                    table.ForeignKey(
                        name: "FK_UserCars_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserCpf",
                        column: x => x.UserCpf,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "UserNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishedByCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "CarImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageStream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserCarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImage_CompanyCars_CompanyCarPlate",
                        column: x => x.CompanyCarPlate,
                        principalTable: "CompanyCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarImage_UserCars_UserCarPlate",
                        column: x => x.UserCarPlate,
                        principalTable: "UserCars",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_CompanyCarPlate",
                table: "CarImage",
                column: "CompanyCarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_UserCarPlate",
                table: "CarImage",
                column: "UserCarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CityId",
                table: "CompanyCars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CompanyCnpj",
                table: "CompanyCars",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogins_CompanyCnpj",
                table: "CompanyLogins",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_PublishedByCnpj",
                table: "CompanyNews",
                column: "PublishedByCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CityId",
                table: "UserCars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_UserCpf",
                table: "UserCars",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpf",
                table: "UserLogins",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_PublishedByCpf",
                table: "UserNews",
                column: "PublishedByCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImage");

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
