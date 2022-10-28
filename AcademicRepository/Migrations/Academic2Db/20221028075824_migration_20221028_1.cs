using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_09_23.Migrations.Academic2Db
{
    public partial class migration_20221028_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentsStudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsSubjectId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "SubjectTeacher",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "StudentSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentId",
                table: "StudentSubject",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectsSubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectsId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentsId",
                table: "StudentSubject",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsId",
                table: "StudentSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentsId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "SubjectTeacher",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "StudentSubject",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "StudentSubject",
                newName: "StudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectsId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentsStudentId",
                table: "StudentSubject",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsSubjectId",
                table: "StudentSubject",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
