using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.Data.Migrations
{
    public partial class Foreign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlateFk",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_UserCars_CarPlateFk",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpjFk",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCities_Companies_CompanyCnpjFk",
                table: "CompanyCities");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpjFk",
                table: "CompanyLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpjFk",
                table: "CompanyNews");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpjFk",
                table: "CompanyNews",
                newName: "CompanyCnpj");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyNews_CompanyCnpjFk",
                table: "CompanyNews",
                newName: "IX_CompanyNews_CompanyCnpj");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpjFk",
                table: "CompanyLogins",
                newName: "CompanyCnpj");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLogins_CompanyCnpjFk",
                table: "CompanyLogins",
                newName: "IX_CompanyLogins_CompanyCnpj");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpjFk",
                table: "CompanyCities",
                newName: "CompanyCnpj");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCities_CompanyCnpjFk",
                table: "CompanyCities",
                newName: "IX_CompanyCities_CompanyCnpj");

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
                table: "CarImages",
                newName: "CarPlate");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_CarPlateFk",
                table: "CarImages",
                newName: "IX_CarImages_CarPlate");

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
                name: "FK_CompanyCars_Companies_CompanyCnpj",
                table: "CompanyCars",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCities_Companies_CompanyCnpj",
                table: "CompanyCities",
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpj",
                table: "CompanyNews",
                column: "CompanyCnpj",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_CompanyCars_CarPlate",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_UserCars_CarPlate",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCars_Companies_CompanyCnpj",
                table: "CompanyCars");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCities_Companies_CompanyCnpj",
                table: "CompanyCities");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogins_Companies_CompanyCnpj",
                table: "CompanyLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNews_Companies_CompanyCnpj",
                table: "CompanyNews");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpj",
                table: "CompanyNews",
                newName: "CompanyCnpjFk");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyNews_CompanyCnpj",
                table: "CompanyNews",
                newName: "IX_CompanyNews_CompanyCnpjFk");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpj",
                table: "CompanyLogins",
                newName: "CompanyCnpjFk");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLogins_CompanyCnpj",
                table: "CompanyLogins",
                newName: "IX_CompanyLogins_CompanyCnpjFk");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpj",
                table: "CompanyCities",
                newName: "CompanyCnpjFk");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCities_CompanyCnpj",
                table: "CompanyCities",
                newName: "IX_CompanyCities_CompanyCnpjFk");

            migrationBuilder.RenameColumn(
                name: "CompanyCnpj",
                table: "CompanyCars",
                newName: "CompanyCnpjFk");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCars_CompanyCnpj",
                table: "CompanyCars",
                newName: "IX_CompanyCars_CompanyCnpjFk");

            migrationBuilder.RenameColumn(
                name: "CarPlate",
                table: "CarImages",
                newName: "CarPlateFk");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_CarPlate",
                table: "CarImages",
                newName: "IX_CarImages_CarPlateFk");

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
                name: "FK_CompanyCars_Companies_CompanyCnpjFk",
                table: "CompanyCars",
                column: "CompanyCnpjFk",
                principalTable: "Companies",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCities_Companies_CompanyCnpjFk",
                table: "CompanyCities",
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
        }
    }
}
