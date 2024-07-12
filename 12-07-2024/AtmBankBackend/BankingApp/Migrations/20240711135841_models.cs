using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    AtmId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Transactions_Atms_AtmId",
                        column: x => x.AtmId,
                        principalTable: "Atms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "Cards",
                        principalColumn: "CardNumber");
                });

            migrationBuilder.InsertData(
                table: "Atms",
                columns: new[] { "Id", "BankName", "Location" },
                values: new object[,]
                {
                    { 1, "A Bank", "123 Park Ave" },
                    { 2, "B Bank", "456 Elm St" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", "John Doe", "123-456-7890" },
                    { 2, "456 Elm St", "Jane Smith", "987-654-3210" },
                    { 3, "789 Oak St", "Alice Johnson", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "CurrentAmount", "DateOfCreation", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, 5000.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5456), "Savings", 1 },
                    { 2L, 25000.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459), "Current", 1 },
                    { 3L, 3000.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459), "Savings", 2 },
                    { 4L, 8000.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5460), "Current", 3 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "AccountId", "BankName", "Expiry", "PIN" },
                values: new object[] { 1234567890123456L, 1L, "A Bank", new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5470), "1234" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "AccountId", "BankName", "Expiry", "PIN" },
                values: new object[] { 2345678901234567L, 2L, "B Bank", new DateTime(2026, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5475), "5678" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "AccountId", "BankName", "Expiry", "PIN" },
                values: new object[] { 3456789012345678L, 3L, "A Bank", new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5476), "9876" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "AtmId", "CardNumber", "TransactionAmount", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1L, 1, 1234567890123456L, 50.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5490), "Withdrawal" },
                    { 2, 1L, 2, 1234567890123456L, 100.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5491), "Deposit" },
                    { 3, 2L, 1, 2345678901234567L, 20.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5492), "Withdrawal" },
                    { 4, 2L, 2, 2345678901234567L, 10.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493), "Withdrawal" },
                    { 5, 3L, 1, 3456789012345678L, 200.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493), "Deposit" },
                    { 6, 3L, 2, 3456789012345678L, 50.0, new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5494), "Withdrawal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountId",
                table: "Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AtmId",
                table: "Transactions",
                column: "AtmId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardNumber",
                table: "Transactions",
                column: "CardNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Atms");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
