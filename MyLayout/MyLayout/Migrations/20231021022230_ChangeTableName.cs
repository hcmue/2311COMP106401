using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLayout.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoas_Loais_MaLoai",
                table: "HangHoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loais",
                table: "Loais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas");

            migrationBuilder.RenameTable(
                name: "Loais",
                newName: "Loai");

            migrationBuilder.RenameTable(
                name: "HangHoas",
                newName: "HangHoa");

            migrationBuilder.RenameIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoa",
                newName: "IX_HangHoa_MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loai",
                table: "Loai",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoa",
                table: "HangHoa",
                column: "MaHh");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa",
                column: "MaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loai",
                table: "Loai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoa",
                table: "HangHoa");

            migrationBuilder.RenameTable(
                name: "Loai",
                newName: "Loais");

            migrationBuilder.RenameTable(
                name: "HangHoa",
                newName: "HangHoas");

            migrationBuilder.RenameIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoas",
                newName: "IX_HangHoas_MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loais",
                table: "Loais",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas",
                column: "MaHh");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoas_Loais_MaLoai",
                table: "HangHoas",
                column: "MaLoai",
                principalTable: "Loais",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
