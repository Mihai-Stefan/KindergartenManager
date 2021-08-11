using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class AddedSomeNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KidImages_Kid_KidId",
                table: "KidImages");

            migrationBuilder.DropForeignKey(
                name: "FK_KidParents_Kid_KidId",
                table: "KidParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kid",
                table: "Kid");

            migrationBuilder.RenameTable(
                name: "Kid",
                newName: "Kids");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Kids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kids",
                table: "Kids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KidImages_Kids_KidId",
                table: "KidImages",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KidParents_Kids_KidId",
                table: "KidParents",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KidImages_Kids_KidId",
                table: "KidImages");

            migrationBuilder.DropForeignKey(
                name: "FK_KidParents_Kids_KidId",
                table: "KidParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kids",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Kids");

            migrationBuilder.RenameTable(
                name: "Kids",
                newName: "Kid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kid",
                table: "Kid",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KidImages_Kid_KidId",
                table: "KidImages",
                column: "KidId",
                principalTable: "Kid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KidParents_Kid_KidId",
                table: "KidParents",
                column: "KidId",
                principalTable: "Kid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
