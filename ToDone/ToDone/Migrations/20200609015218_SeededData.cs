using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDone.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Assignee", "DueDate", "Name" },
                values: new object[] { 1, "Francesco", new DateTime(2020, 6, 8, 20, 49, 20, 0, DateTimeKind.Utc), "Fake Company" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
