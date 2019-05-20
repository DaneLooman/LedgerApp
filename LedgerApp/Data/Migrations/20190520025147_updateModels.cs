using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LedgerApp.Data.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TranAccountId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TranAccountId",
                table: "Transactions",
                column: "TranAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_TranAccountId",
                table: "Transactions",
                column: "TranAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_TranAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TranAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TranAccountId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TranAccountAccountNum",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TranAccountAccountNum",
                table: "Transactions",
                column: "TranAccountAccountNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_TranAccountAccountNum",
                table: "Transactions",
                column: "TranAccountAccountNum",
                principalTable: "Accounts",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
