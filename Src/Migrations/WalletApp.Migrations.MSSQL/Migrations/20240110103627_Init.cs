using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limit = table.Column<float>(type: "real", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardBalances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sum = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pending = table.Column<bool>(type: "bit", nullable: false),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardBalanceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CardBalanceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_CardBalances_CardBalanceId",
                        column: x => x.CardBalanceId,
                        principalTable: "CardBalances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_CardBalances_CardBalanceId1",
                        column: x => x.CardBalanceId1,
                        principalTable: "CardBalances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Admin", "pass" },
                    { 2, "Ann", "pass2" }
                });

            migrationBuilder.InsertData(
                table: "CardBalances",
                columns: new[] { "Id", "Balance", "Limit", "UserId" },
                values: new object[] { 1, 1390f, 1500f, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CardBalanceId", "CardBalanceId1", "Date", "Description", "IconPath", "Name", "Pending", "Sum", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 2, 1, null, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 3, 1, null, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 1, 1 },
                    { 4, 1, null, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 5, 1, null, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", false, 24.5f, 1, 1 },
                    { 6, 1, null, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 2 },
                    { 7, 1, null, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 8, 1, null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 9, 1, null, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", false, 27.5f, 0, 1 },
                    { 10, 1, null, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 1 },
                    { 11, 1, null, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Текст", "path", "IKEA", true, 24.5f, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardBalances_Id",
                table: "CardBalances",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardBalances_UserId",
                table: "CardBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardBalanceId",
                table: "Transactions",
                column: "CardBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardBalanceId1",
                table: "Transactions",
                column: "CardBalanceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Id",
                table: "Transactions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CardBalances");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
