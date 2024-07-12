using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Migrations
{
    public partial class edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 1234567890123456L,
                column: "Expiry",
                value: new DateTime(2027, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 2345678901234567L,
                column: "Expiry",
                value: new DateTime(2026, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 3456789012345678L,
                column: "Expiry",
                value: new DateTime(2027, 7, 12, 4, 56, 21, 57, DateTimeKind.Utc).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 12, 10, 26, 21, 57, DateTimeKind.Local).AddTicks(2756));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4L,
                column: "DateOfCreation",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 1234567890123456L,
                column: "Expiry",
                value: new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 2345678901234567L,
                column: "Expiry",
                value: new DateTime(2026, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardNumber",
                keyValue: 3456789012345678L,
                column: "Expiry",
                value: new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "TransactionDate",
                value: new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5494));
        }
    }
}
