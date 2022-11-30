using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classroom.Mvc.Data.Migrations
{
    public partial class TaskComment_Type_Edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12335256-f94d-4559-b7df-1a20294308da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65b40458-7c81-476e-b2e2-44a019455811"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("de63222e-8119-494f-8227-444dbcb48140"));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "TaskComments",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4bcafac1-b5ad-46c4-a495-08b1ecfdcdd6"), "593221e7-5496-46f3-a9d2-8393561e77ba", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b3a3c522-4dcd-4d65-a2ce-dbf05b0230b0"), "c35c3130-bfb1-45ce-99ec-753a26520764", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c0da25eb-a1af-450c-b952-1f7e498dd8aa"), "5cd92d98-ed98-4479-beac-a846c00af12f", "Teacher", "TEACHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4bcafac1-b5ad-46c4-a495-08b1ecfdcdd6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3a3c522-4dcd-4d65-a2ce-dbf05b0230b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0da25eb-a1af-450c-b952-1f7e498dd8aa"));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "TaskComments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("12335256-f94d-4559-b7df-1a20294308da"), "728cbcbf-ac03-46de-ba14-b07e418dbdad", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("65b40458-7c81-476e-b2e2-44a019455811"), "6bda9fc8-c701-430c-8ad9-77370211be07", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("de63222e-8119-494f-8227-444dbcb48140"), "1b2f4a96-b1c4-4a20-b50b-8e2f9943a85f", "Admin", "ADMIN" });
        }
    }
}
