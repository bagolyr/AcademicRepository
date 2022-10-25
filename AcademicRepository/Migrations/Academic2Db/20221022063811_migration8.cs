using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_09_23.Migrations.Academic2Db
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Semesters",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Semesters",
                newName: "SemesterId");
        }
    }
}
