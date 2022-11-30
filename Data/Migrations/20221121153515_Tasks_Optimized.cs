using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Tasks_Optimized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2d790dd3-f175-4dee-8952-4773455291b5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4341536d-cf5f-42b4-a015-7c75ee95845f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3dfb5b1-8b4d-4bd2-ba0b-0bac7bac2477"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("56f63e66-4bc7-496d-86eb-17194cd46789"), "754d0770-11fd-4bf7-9119-48cc0ad80180", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("65e40389-6b33-4fee-bbba-e35863f50051"), "1a467379-8129-4cd1-99bd-09c6ef0c0f04", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ca563ff0-ffc3-42c9-b177-855a5132a44c"), "f0186f25-9cc7-4afe-8775-1001255f8f4a", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56f63e66-4bc7-496d-86eb-17194cd46789"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65e40389-6b33-4fee-bbba-e35863f50051"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca563ff0-ffc3-42c9-b177-855a5132a44c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2d790dd3-f175-4dee-8952-4773455291b5"), "470ab529-8be3-451c-bb71-5919fe01a482", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4341536d-cf5f-42b4-a015-7c75ee95845f"), "6fb79654-2da7-45c5-8fa5-37fb9921b60d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d3dfb5b1-8b4d-4bd2-ba0b-0bac7bac2477"), "c578a8ef-98a8-47c8-9540-78d94027210c", "Student", "STUDENT" });
        }
    }
}
