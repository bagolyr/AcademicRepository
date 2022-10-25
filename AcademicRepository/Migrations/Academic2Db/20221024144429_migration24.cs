using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_09_23.Migrations.Academic2Db
{
    public partial class migration24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "SubjectTeacher",
                newName: "TeacherId_FK");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectTeacher",
                newName: "SubjectId_FK");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeacherId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId_FK",
                table: "SubjectTeacher",
                column: "SubjectId_FK",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId_FK",
                table: "SubjectTeacher",
                column: "TeacherId_FK",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId_FK",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId_FK",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId_FK",
                table: "SubjectTeacher",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectId_FK",
                table: "SubjectTeacher",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeacherId_FK",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
