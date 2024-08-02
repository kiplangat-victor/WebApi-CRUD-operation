using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class markss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Marks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "studentsId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_studentsId",
                table: "Marks",
                column: "studentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks",
                column: "studentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_studentsId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_studentsId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "studentsId",
                table: "Marks");
        }
    }
}
