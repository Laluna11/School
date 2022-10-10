using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Courses.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nationality_NationalityID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "NationalityID",
                table: "Students",
                newName: "NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_NationalityID",
                table: "Students",
                newName: "IX_Students_NationalityId");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nationality_NationalityId",
                table: "Students",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "NationalityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nationality_NationalityId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Students",
                newName: "NationalityID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_NationalityId",
                table: "Students",
                newName: "IX_Students_NationalityID");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityID",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nationality_NationalityID",
                table: "Students",
                column: "NationalityID",
                principalTable: "Nationality",
                principalColumn: "NationalityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
