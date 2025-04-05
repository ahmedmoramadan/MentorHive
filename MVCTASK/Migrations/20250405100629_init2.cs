using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTASK.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructores_courses_CrsId",
                table: "instructores");

            migrationBuilder.DropForeignKey(
                name: "FK_instructores_departments_DepartmentId",
                table: "instructores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructores",
                table: "instructores");

            migrationBuilder.RenameTable(
                name: "instructores",
                newName: "instructors");

            migrationBuilder.RenameIndex(
                name: "IX_instructores_DepartmentId",
                table: "instructors",
                newName: "IX_instructors_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_instructores_CrsId",
                table: "instructors",
                newName: "IX_instructors_CrsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructors",
                table: "instructors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_CrsId",
                table: "instructors",
                column: "CrsId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_DepartmentId",
                table: "instructors",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_CrsId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_DepartmentId",
                table: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructors",
                table: "instructors");

            migrationBuilder.RenameTable(
                name: "instructors",
                newName: "instructores");

            migrationBuilder.RenameIndex(
                name: "IX_instructors_DepartmentId",
                table: "instructores",
                newName: "IX_instructores_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_instructors_CrsId",
                table: "instructores",
                newName: "IX_instructores_CrsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructores",
                table: "instructores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_instructores_courses_CrsId",
                table: "instructores",
                column: "CrsId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructores_departments_DepartmentId",
                table: "instructores",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
