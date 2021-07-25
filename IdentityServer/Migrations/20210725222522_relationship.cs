using Microsoft.EntityFrameworkCore.Migrations;

namespace ICar.IdentityServer.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CityId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_News_UserId",
                table: "News",
                newName: "IX_News_OwnerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cars",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                newName: "IX_Cars_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "NVARCHAR(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Cars",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_OwnerId",
                table: "News",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_OwnerId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CityId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "News",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_News_OwnerId",
                table: "News",
                newName: "IX_News_UserId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Cars",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                newName: "IX_Cars_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Cars",
                type: "INT",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Cars",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
