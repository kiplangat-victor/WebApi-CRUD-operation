using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "studentsId",
                table: "Marks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_studentsId",
                table: "Marks",
                newName: "IX_Marks_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Marks",
                newName: "studentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                newName: "IX_Marks_studentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks",
                column: "studentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
