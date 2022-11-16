using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class Course_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sciences_Schools_SchoolId",
                table: "Sciences");

            migrationBuilder.DropTable(
                name: "UserSciences");

            migrationBuilder.DropIndex(
                name: "IX_Sciences_SchoolId",
                table: "Sciences");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5947cb11-f41e-4b8e-8cbd-955733598666"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac6c22d1-d358-420d-90c0-a38357eafe35"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad565139-b7ac-4994-8738-48fb6e29e738"));

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Sciences");

            migrationBuilder.AddColumn<string>(
                name: "Audience",
                table: "Sciences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sciences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityKey",
                table: "Sciences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Sciences_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Sciences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourses");

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
                name: "Audience",
                table: "Sciences");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sciences");

            migrationBuilder.DropColumn(
                name: "SecurityKey",
                table: "Sciences");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolId",
                table: "Sciences",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserSciences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScienceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSciences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSciences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSciences_Sciences_ScienceId",
                        column: x => x.ScienceId,
                        principalTable: "Sciences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5947cb11-f41e-4b8e-8cbd-955733598666"), "979f0764-be0d-4e7a-bbed-433d1e3129a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ac6c22d1-d358-420d-90c0-a38357eafe35"), "cbe7ff1c-fdfc-442b-8fc2-7c0772c4f541", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ad565139-b7ac-4994-8738-48fb6e29e738"), "b5cf4bc2-21e9-4a5d-80c5-89459de83036", "Teacher", "TEACHER" });

            migrationBuilder.CreateIndex(
                name: "IX_Sciences_SchoolId",
                table: "Sciences",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSciences_ScienceId",
                table: "UserSciences",
                column: "ScienceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSciences_UserId",
                table: "UserSciences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sciences_Schools_SchoolId",
                table: "Sciences",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
