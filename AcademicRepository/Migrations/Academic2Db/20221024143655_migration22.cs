using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_09_23.Migrations.Academic2Db
{
    public partial class migration22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "SubjectTeacher",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "SubjectTeacher",
                newName: "TeacherId");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectId", "TeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubjectTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "SubjectTeacher",
                newName: "SubjectsSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectsSubjectId", "TeachersId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
