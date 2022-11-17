using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Course_user_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("281e8639-a42d-4243-9113-40ee9ab0055d"), "80092a3d-074a-499b-8b3d-19bf04466813", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("505611b2-3f57-44a8-9779-1178f137374a"), "6c08dc01-4abf-4d34-93ee-1ed92880874c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e155db97-1290-45f8-9b83-dfc3b8d8d570"), "eca59b61-e00f-4244-abd8-ad1068dd090d", "Teacher", "TEACHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("281e8639-a42d-4243-9113-40ee9ab0055d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("505611b2-3f57-44a8-9779-1178f137374a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e155db97-1290-45f8-9b83-dfc3b8d8d570"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserCourses");

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
    }
}
