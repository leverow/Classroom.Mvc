using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Task_StartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8016b620-391b-40e0-9b47-3f3804c38882"), "22f5014c-e2e7-4fd4-a13e-6c39ddfa4742", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("94142128-6f9c-4c53-a612-fe812aeae1f1"), "923bb37e-8731-43e6-ba08-4a8823e9c596", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a823fb53-fc73-4ae3-b1eb-aaef1957ad74"), "7b5d10d3-106c-4d7b-881d-2d8e7ce21f3a", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8016b620-391b-40e0-9b47-3f3804c38882"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94142128-6f9c-4c53-a612-fe812aeae1f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a823fb53-fc73-4ae3-b1eb-aaef1957ad74"));

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
        }
    }
}
