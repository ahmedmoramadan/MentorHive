using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTASK.Migrations
{
    /// <inheritdoc />
    public partial class editcompisitkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_crsReselts",
                table: "crsReselts");

            migrationBuilder.DropIndex(
                name: "IX_crsReselts_TraineeId",
                table: "crsReselts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "crsReselts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_crsReselts",
                table: "crsReselts",
                columns: new[] { "TraineeId", "CourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_crsReselts",
                table: "crsReselts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "crsReselts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_crsReselts",
                table: "crsReselts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_crsReselts_TraineeId",
                table: "crsReselts",
                column: "TraineeId");
        }
    }
}
