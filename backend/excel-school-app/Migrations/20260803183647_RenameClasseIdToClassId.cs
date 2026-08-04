using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace excel_school_app.Migrations
{
    /// <inheritdoc />
    public partial class RenameClasseIdToClassId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Student",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Student",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Student",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");
        }
    }
}
