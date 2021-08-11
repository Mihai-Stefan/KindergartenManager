using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class AddKidParentTableCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KidImage_Kid_KidId",
                table: "KidImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KidImage",
                table: "KidImage");

            migrationBuilder.RenameTable(
                name: "KidImage",
                newName: "KidImages");

            migrationBuilder.RenameIndex(
                name: "IX_KidImage_KidId",
                table: "KidImages",
                newName: "IX_KidImages_KidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KidImages",
                table: "KidImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KidParents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLegalTutor = table.Column<bool>(type: "bit", nullable: false),
                    ParentJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentWorkplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KidId = table.Column<int>(type: "int", nullable: true),
                    IconStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KidParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KidParents_Kid_KidId",
                        column: x => x.KidId,
                        principalTable: "Kid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KidParents_KidId",
                table: "KidParents",
                column: "KidId");

            migrationBuilder.AddForeignKey(
                name: "FK_KidImages_Kid_KidId",
                table: "KidImages",
                column: "KidId",
                principalTable: "Kid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KidImages_Kid_KidId",
                table: "KidImages");

            migrationBuilder.DropTable(
                name: "KidParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KidImages",
                table: "KidImages");

            migrationBuilder.RenameTable(
                name: "KidImages",
                newName: "KidImage");

            migrationBuilder.RenameIndex(
                name: "IX_KidImages_KidId",
                table: "KidImage",
                newName: "IX_KidImage_KidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KidImage",
                table: "KidImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KidImage_Kid_KidId",
                table: "KidImage",
                column: "KidId",
                principalTable: "Kid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
