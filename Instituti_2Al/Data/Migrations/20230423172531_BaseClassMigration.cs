using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instituti_2Al.Data.Migrations
{
    public partial class BaseClassMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_DeletedById",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_PersonId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UpdatedById",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "BaseClasses");

            migrationBuilder.RenameIndex(
                name: "IX_Course_UpdatedById",
                table: "BaseClasses",
                newName: "IX_BaseClasses_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Course_PersonId",
                table: "BaseClasses",
                newName: "IX_BaseClasses_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_DeletedById",
                table: "BaseClasses",
                newName: "IX_BaseClasses_DeletedById");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BaseClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "BaseClasses",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BaseClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Featured",
                table: "BaseClasses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BaseClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "BaseClasses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BaseClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseClasses",
                table: "BaseClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseClasses_AspNetUsers_DeletedById",
                table: "BaseClasses",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseClasses_AspNetUsers_PersonId",
                table: "BaseClasses",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseClasses_AspNetUsers_UpdatedById",
                table: "BaseClasses",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseClasses_AspNetUsers_DeletedById",
                table: "BaseClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseClasses_AspNetUsers_PersonId",
                table: "BaseClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseClasses_AspNetUsers_UpdatedById",
                table: "BaseClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseClasses",
                table: "BaseClasses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseClasses");

            migrationBuilder.RenameTable(
                name: "BaseClasses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_BaseClasses_UpdatedById",
                table: "Course",
                newName: "IX_Course_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_BaseClasses_PersonId",
                table: "Course",
                newName: "IX_Course_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseClasses_DeletedById",
                table: "Course",
                newName: "IX_Course_DeletedById");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Course",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Featured",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_DeletedById",
                table: "Course",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_PersonId",
                table: "Course",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UpdatedById",
                table: "Course",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
