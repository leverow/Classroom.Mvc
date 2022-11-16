using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Course_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f9c8c79-fd41-47e1-9168-2466652fdb59"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("67bf7ac4-c394-4047-b21a-b8352c61b4b6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70fe1d05-f220-4998-b777-70cd936e46e0"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("7cd422c3-5271-4706-8472-b00c4f42c0e3"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCourses");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4f9c8c79-fd41-47e1-9168-2466652fdb59"), "658808c8-246b-4380-922b-2b923786ad83", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("67bf7ac4-c394-4047-b21a-b8352c61b4b6"), "a91292d2-cd82-417c-b8b9-d4b4333c17c7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("70fe1d05-f220-4998-b777-70cd936e46e0"), "f9094446-2553-434f-a8f6-dc35d5c6d263", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("7cd422c3-5271-4706-8472-b00c4f42c0e3"), "Some description", "80-maktab" });
        }
    }
}
