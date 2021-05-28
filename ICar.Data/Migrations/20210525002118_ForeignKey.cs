using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Data.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImage_CompanyCars_CompanyCarPlate",
                table: "CarImage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImage_UserCars_UserCarPlate",
                table: "CarImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Companies_CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Cities_CityId",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpj",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpj",
                table: "CompanyLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNews_Companies_PublishedByCnpj",
                table: "CompanyNews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Cities_CityId",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Users_UserCpf",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserCpf",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNews_Users_PublishedByCpf",
                table: "UserNews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserNews_PublishedByCpf",
                table: "UserNews");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserCpf",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_CompanyNews_PublishedByCnpj",
                table: "CompanyNews");

            migrationBuilder.DropIndex(
                name: "IX_CompanyLogins_CompanyCnpj",
                table: "CompanyLogins");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage");

            migrationBuilder.DropIndex(
                name: "IX_CarImage_CompanyCarPlate",
                table: "CarImage");

            migrationBuilder.DropColumn(
                name: "PublishedByCpf",
                table: "UserNews");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "PublishedByCnpj",
                table: "CompanyNews");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj",
                table: "CompanyLogins");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "CarImage");

            migrationBuilder.DropColumn(
                name: "CompanyCarPlate",
                table: "CarImage");

            migrationBuilder.RenameTable(
                name: "CarImage",
                newName: "CarImages");

            migrationBuilder.RenameColumn(
                name: "UserCpf",
                table: "UserCars",
                newName: "UserCpf");

            migrationBuilder.RenameIndex(
                name: "IX_UserCars_UserCpf",
                table: "UserCars",
                newName: "IX_UserCars_UserCpfFk");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpj",
                table: "CompanyCars",
                newName: "CompanyCnpjFk");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCars_CompanyCnpj",
                table: "CompanyCars",
                newName: "IX_CompanyCars_CompanyCnpjFk");

            migrationBuilder.RenameColumn(
                name: "UserCarPlate",
                table: "CarImages",
                newName: "CarPlateFk");

            migrationBuilder.RenameIndex(
                name: "IX_CarImage_UserCarPlate",
                table: "CarImages",
                newName: "IX_CarImages_CarPlateFk");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "UserNews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserCars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpjFk",
                table: "CompanyNews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpjFk",
                table: "CompanyLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "CompanyCars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyCnpjFk = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCities_Cities_Id",
                        column: x => x.Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCities_Companies_CompanyCnpjFk",
                        column: x => x.CompanyCnpjFk,
                        principalTable: "Companies",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_UserCpfFk",
                table: "UserNews",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpfFk",
                table: "UserLogins",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_CompanyCnpjFk",
                table: "CompanyNews",
                column: "CompanyCnpjFk");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogins_CompanyCnpjFk",
                table: "CompanyLogins",
                column: "CompanyCnpjFk");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCities_CompanyCnpjFk",
                table: "CompanyCities",
                column: "CompanyCnpjFk");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlateFk",
                table: "CarImages",
                column: "CarPlateFk",
                principalTable: "CompanyCars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_UserCars_CarPlateFk",
                table: "CarImages",
                column: "CarPlateFk",
                principalTable: "UserCars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Cities_CityId",
                table: "CompanyCars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpjFk",
                table: "CompanyCars",
                column: "CompanyCnpjFk",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpjFk",
                table: "CompanyLogins",
                column: "CompanyCnpjFk",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpjFk",
                table: "CompanyNews",
                column: "CompanyCnpjFk",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Cities_CityId",
                table: "UserCars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Users_UserCpfFk",
                table: "UserCars",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserCpfFk",
                table: "UserLogins",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNews_Users_UserCpfFk",
                table: "UserNews",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlateFk",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_UserCars_CarPlateFk",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Cities_CityId",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpjFk",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpjFk",
                table: "CompanyLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpjFk",
                table: "CompanyNews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Cities_CityId",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Users_UserCpfFk",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserCpfFk",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNews_Users_UserCpfFk",
                table: "UserNews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CompanyCities");

            migrationBuilder.DropIndex(
                name: "IX_UserNews_UserCpfFk",
                table: "UserNews");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserCpfFk",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_CompanyNews_CompanyCnpjFk",
                table: "CompanyNews");

            migrationBuilder.DropIndex(
                name: "IX_CompanyLogins_CompanyCnpjFk",
                table: "CompanyLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "UserNews");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CompanyCnpjFk",
                table: "CompanyNews");

            migrationBuilder.DropColumn(
                name: "CompanyCnpjFk",
                table: "CompanyLogins");

            migrationBuilder.RenameTable(
                name: "CarImages",
                newName: "CarImage");

            migrationBuilder.RenameColumn(
                name: "UserCpf",
                table: "UserCars",
                newName: "UserCpf");

            migrationBuilder.RenameIndex(
                name: "IX_UserCars_UserCpfFk",
                table: "UserCars",
                newName: "IX_UserCars_UserCpf");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpjFk",
                table: "CompanyCars",
                newName: "CompanyCnpj");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCars_CompanyCnpjFk",
                table: "CompanyCars",
                newName: "IX_CompanyCars_CompanyCnpj");

            migrationBuilder.RenameColumn(
                name: "CarPlateFk",
                table: "CarImage",
                newName: "UserCarPlate");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_CarPlateFk",
                table: "CarImage",
                newName: "IX_CarImage_UserCarPlate");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PublishedByCpf",
                table: "UserNews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "UserCars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PublishedByCnpj",
                table: "CompanyNews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj",
                table: "CompanyLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "CompanyCars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "CarImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCarPlate",
                table: "CarImage",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_PublishedByCpf",
                table: "UserNews",
                column: "PublishedByCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpf",
                table: "UserLogins",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_PublishedByCnpj",
                table: "CompanyNews",
                column: "PublishedByCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogins_CompanyCnpj",
                table: "CompanyLogins",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_CompanyCarPlate",
                table: "CarImage",
                column: "CompanyCarPlate");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImage_CompanyCars_CompanyCarPlate",
                table: "CarImage",
                column: "CompanyCarPlate",
                principalTable: "CompanyCars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarImage_UserCars_UserCarPlate",
                table: "CarImage",
                column: "UserCarPlate",
                principalTable: "UserCars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Companies_CompanyCnpj",
                table: "Cities",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Cities_CityId",
                table: "CompanyCars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpj",
                table: "CompanyCars",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpj",
                table: "CompanyLogins",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNews_Companies_PublishedByCnpj",
                table: "CompanyNews",
                column: "PublishedByCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Cities_CityId",
                table: "UserCars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Users_UserCpf",
                table: "UserCars",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserCpf",
                table: "UserLogins",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNews_Users_PublishedByCpf",
                table: "UserNews",
                column: "PublishedByCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
