using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Removed_School : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_ScienceId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Schools");

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

            migrationBuilder.RenameColumn(
                name: "ScienceId",
                table: "Tasks",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ScienceId",
                table: "Tasks",
                newName: "IX_Tasks_CourseId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("237bfa0c-f860-4958-97a2-21baf9699dc3"), "f620d793-aa5d-49de-976b-9cfde3c7a9f3", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("43921703-c4b4-472c-9e23-0d112a77a86c"), "50cfb266-e095-4290-b9cd-996b65537d6f", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("51fdfc76-2d46-4365-9f8a-179344d80c3a"), "bd9cdef0-e4ac-42f5-a60b-a881e8eb1685", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("237bfa0c-f860-4958-97a2-21baf9699dc3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43921703-c4b4-472c-9e23-0d112a77a86c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("51fdfc76-2d46-4365-9f8a-179344d80c3a"));

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Tasks",
                newName: "ScienceId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CourseId",
                table: "Tasks",
                newName: "IX_Tasks_ScienceId");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

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
                name: "FK_Tasks_Courses_ScienceId",
                table: "Tasks",
                column: "ScienceId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
