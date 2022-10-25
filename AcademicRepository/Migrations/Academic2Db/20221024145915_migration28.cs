using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2022_09_23.Migrations.Academic2Db
{
    public partial class migration28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId_FK",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId_FK",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeacher_TeacherId_FK",
                table: "SubjectTeacher");

            migrationBuilder.DropColumn(
                name: "SubjectId_FK",
                table: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubjectTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "TeacherId_FK",
                table: "SubjectTeacher",
                newName: "SubjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectsId", "TeachersId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsId",
                table: "SubjectTeacher");


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
                name: "SubjectsId",
                table: "SubjectTeacher",
                newName: "TeacherId_FK");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId_FK",
                table: "SubjectTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "SubjectId_FK", "TeacherId_FK" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId_FK",
                table: "SubjectTeacher",
                column: "TeacherId_FK");

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
    }
}
