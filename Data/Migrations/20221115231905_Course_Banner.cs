using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Course_Banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sciences_AspNetUsers_CreatedBy",
                table: "Sciences");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sciences_ScienceId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Sciences_CourseId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sciences",
                table: "Sciences");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4bcb8bda-7345-46dd-9ab6-0c47bed0ba05"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("603ea272-ca4c-4677-92c9-21ea8f34faa9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f55a54d8-b907-4615-97e2-d013091110d1"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("9da201cd-249f-45f0-bd87-075743c49fae"));

            migrationBuilder.RenameTable(
                name: "Sciences",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Sciences_CreatedBy",
                table: "Courses",
                newName: "IX_Courses_CreatedBy");

            migrationBuilder.AddColumn<uint>(
                name: "ImageType",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0fff95ee-2621-4d99-967b-758dfd745167"), "3e319d21-07f8-4493-8d8a-a7a7dec22745", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("316ee362-7d6f-4554-b967-c2bda6c768d8"), "f4f827ac-0fed-4579-9072-eefc450a4694", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c5888308-6238-4f24-ad8d-b25b7af3ccfe"), "f8e056e1-5bcc-43ad-84b2-f1aa7e45075c", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("19ab2007-84d2-4a3f-bf09-36bca02e2ac4"), "Some description", "80-maktab" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CreatedBy",
                table: "Courses",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_ScienceId",
                table: "Tasks",
                column: "ScienceId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CreatedBy",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_ScienceId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fff95ee-2621-4d99-967b-758dfd745167"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("316ee362-7d6f-4554-b967-c2bda6c768d8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5888308-6238-4f24-ad8d-b25b7af3ccfe"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("19ab2007-84d2-4a3f-bf09-36bca02e2ac4"));

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Sciences");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CreatedBy",
                table: "Sciences",
                newName: "IX_Sciences_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sciences",
                table: "Sciences",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4bcb8bda-7345-46dd-9ab6-0c47bed0ba05"), "7f3d478e-6c10-448c-bbc7-b79b819e2a4a", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("603ea272-ca4c-4677-92c9-21ea8f34faa9"), "1daf3573-ec8b-4a86-aa3e-836a3ee30114", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f55a54d8-b907-4615-97e2-d013091110d1"), "6d251fab-3e5c-4ae9-b9ed-97d04a3557bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("9da201cd-249f-45f0-bd87-075743c49fae"), "Some description", "80-maktab" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sciences_AspNetUsers_CreatedBy",
                table: "Sciences",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sciences_ScienceId",
                table: "Tasks",
                column: "ScienceId",
                principalTable: "Sciences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Sciences_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Sciences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
