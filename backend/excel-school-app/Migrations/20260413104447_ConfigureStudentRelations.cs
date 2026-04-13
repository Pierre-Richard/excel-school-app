using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace excel_school_app.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureStudentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_ClasseId",
                table: "Student",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClasseId",
                table: "Student",
                column: "ClasseId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClasseId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ClasseId",
                table: "Student");
        }
    }
}
