using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Department", "Email", "EmployeeCode", "IsActive", "JoiningDate", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "hemanth@example.com", "EMP001", true, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hemanth Pudi" },
                    { 2, "HR", "pradeep@example.com", "EMP002", true, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pradeep Savara" },
                    { 3, "Finance", "arjun@example.com", "EMP003", true, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arjun Reddy" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "LeaveTypeId", "IsActive", "LeaveTypeName", "MaximumDays" },
                values: new object[,]
                {
                    { 1, true, "Casual Leave", 12 },
                    { 2, true, "Sick Leave", 10 },
                    { 3, true, "Earned Leave", 15 }
                });

            migrationBuilder.InsertData(
                table: "LeaveBalances",
                columns: new[] { "LeaveBalanceId", "EmployeeId", "LeaveTypeId", "TotalDays" },
                values: new object[,]
                {
                    { 1, 1, 1, 12 },
                    { 2, 1, 2, 10 },
                    { 3, 1, 3, 15 },
                    { 4, 2, 1, 12 },
                    { 5, 2, 2, 10 },
                    { 6, 2, 3, 15 },
                    { 7, 3, 1, 12 },
                    { 8, 3, 2, 10 },
                    { 9, 3, 3, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "LeaveBalanceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 3);
        }
    }
}
