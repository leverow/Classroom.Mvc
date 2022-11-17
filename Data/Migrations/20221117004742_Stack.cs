using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Stack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("9357de78-3259-4c20-8b98-ddff170e3245"), "57bfd144-00b9-4db1-9397-c72666dc8570", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("96961846-57bb-4fe4-9719-97a125439585"), "008f70a9-35a3-49e6-8339-7f4b241b6745", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c75fbbc4-0bb4-479c-bed5-99923e48899a"), "78e78e86-e960-40a6-b581-c8eb70d00a06", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9357de78-3259-4c20-8b98-ddff170e3245"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("96961846-57bb-4fe4-9719-97a125439585"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c75fbbc4-0bb4-479c-bed5-99923e48899a"));

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
    }
}
