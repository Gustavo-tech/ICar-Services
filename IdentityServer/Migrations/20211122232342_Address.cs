using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.IdentityServer.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CityId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "SendAt",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.AlterColumn<int>(
                name: "KilometersTraveled",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR", nullable: true),
                    Location = table.Column<string>(type: "VARCHAR", nullable: true),
                    District = table.Column<string>(type: "VARCHAR", nullable: true),
                    Street = table.Column<string>(type: "VARCHAR", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AddressId",
                table: "Cars",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Addresses_AddressId",
                table: "Cars",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Addresses_AddressId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AddressId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "SendAt");

            migrationBuilder.AlterColumn<double>(
                name: "KilometersTraveled",
                table: "Cars",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cars",
                type: "INT",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
