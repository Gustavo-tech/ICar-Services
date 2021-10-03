using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.IdentityServer.Migrations
{
    public partial class CarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPicture_Cars_CarPlate",
                table: "CarPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarPicture_CarPlate",
                table: "CarPicture");

            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "CarPicture");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Cars",
                type: "Char(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Char(8)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarPicture",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarPicture_CarId",
                table: "CarPicture",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPicture_Cars_CarId",
                table: "CarPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarPicture_CarId",
                table: "CarPicture");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarPicture");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Cars",
                type: "Char(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Char(8)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "CarPicture",
                type: "Char(8)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Plate");

            migrationBuilder.CreateIndex(
                name: "IX_CarPicture_CarPlate",
                table: "CarPicture",
                column: "CarPlate");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPicture_Cars_CarPlate",
                table: "CarPicture",
                column: "CarPlate",
                principalTable: "Cars",
                principalColumn: "Plate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
