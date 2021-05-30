using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Infrastructure.Migrations
{
    public partial class Duplicates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlate",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_UserCars_CarPlate",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Companies_CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Companies_CompanyCnpj1",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Cities_CityId1",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpj1",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpj1",
                table: "CompanyLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpj",
                table: "CompanyNews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Cities_CityId1",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Users_UserCpf1",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserCpf1",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNews_Users_UserCpf",
                table: "UserNews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserNews_UserCpf",
                table: "UserNews");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserCpf1",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserCars_CityId",
                table: "UserCars");

            migrationBuilder.DropIndex(
                name: "IX_UserCars_CityId1",
                table: "UserCars");

            migrationBuilder.DropIndex(
                name: "IX_UserCars_UserCpf1",
                table: "UserCars");

            migrationBuilder.DropIndex(
                name: "IX_CompanyNews_CompanyCnpj",
                table: "CompanyNews");

            migrationBuilder.DropIndex(
                name: "IX_CompanyLogins_CompanyCnpj1",
                table: "CompanyLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCities",
                table: "CompanyCities");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCars_CityId",
                table: "CompanyCars");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCars_CityId1",
                table: "CompanyCars");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCars_CompanyCnpj1",
                table: "CompanyCars");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CompanyCnpj1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarPlate",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "UserNews");

            migrationBuilder.DropColumn(
                name: "UserCpf1",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "UserCars");

            migrationBuilder.DropColumn(
                name: "UserCpf1",
                table: "UserCars");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj",
                table: "CompanyNews");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj1",
                table: "CompanyLogins");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "CompanyCars");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj1",
                table: "CompanyCars");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "CarImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCities",
                table: "CompanyCities",
                columns: new[] { "CompanyCnpj", "CityId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CityId",
                table: "UserCars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CityId",
                table: "CompanyCars",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCars_CityId",
                table: "UserCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCities",
                table: "CompanyCities");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCars_CityId",
                table: "CompanyCars");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Users",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "UserNews",
                type: "CHAR(14)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf1",
                table: "UserLogins",
                type: "CHAR(14)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "UserCars",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf1",
                table: "UserCars",
                type: "CHAR(14)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj",
                table: "CompanyNews",
                type: "CHAR(18)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj1",
                table: "CompanyLogins",
                type: "CHAR(18)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "CompanyCars",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj1",
                table: "CompanyCars",
                type: "CHAR(18)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj",
                table: "Cities",
                type: "CHAR(18)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj1",
                table: "Cities",
                type: "CHAR(18)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "CarImages",
                type: "Char(8)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCities",
                table: "CompanyCities",
                columns: new[] { "CityId", "CompanyCnpj" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId1",
                table: "Users",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_UserCpf",
                table: "UserNews",
                column: "UserCpf");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserCpf1",
                table: "UserLogins",
                column: "UserCpf1");

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
                name: "IX_UserCars_UserCpf1",
                table: "UserCars",
                column: "UserCpf1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyNews_CompanyCnpj",
                table: "CompanyNews",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogins_CompanyCnpj1",
                table: "CompanyLogins",
                column: "CompanyCnpj1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities",
                column: "CompanyCnpj",
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
                name: "IX_CompanyCars_CompanyCnpj1",
                table: "CompanyCars",
                column: "CompanyCnpj1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj",
                table: "Cities",
                column: "CompanyCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CompanyCnpj1",
                table: "Cities",
                column: "CompanyCnpj1");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarPlate",
                table: "CarImages",
                column: "CarPlate");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlate",
                table: "CarImages",
                column: "CarPlate",
                principalTable: "CompanyCars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_UserCars_CarPlate",
                table: "CarImages",
                column: "CarPlate",
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
                name: "FK_Cities_Companies_CompanyCnpj1",
                table: "Cities",
                column: "CompanyCnpj1",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Cities_CityId1",
                table: "CompanyCars",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpj1",
                table: "CompanyCars",
                column: "CompanyCnpj1",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpj1",
                table: "CompanyLogins",
                column: "CompanyCnpj1",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpj",
                table: "CompanyNews",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Cities_CityId1",
                table: "UserCars",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Users_UserCpf1",
                table: "UserCars",
                column: "UserCpf1",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserCpf1",
                table: "UserLogins",
                column: "UserCpf1",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNews_Users_UserCpf",
                table: "UserNews",
                column: "UserCpf",
                principalTable: "Users",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId1",
                table: "Users",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
