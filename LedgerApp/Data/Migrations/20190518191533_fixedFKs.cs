using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LedgerApp.Data.Migrations
{
    public partial class fixedFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranAccountId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TranAccountAccountNum",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountUserId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TranAccountAccountNum",
                table: "Transactions",
                column: "TranAccountAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountUserId",
                table: "Accounts",
                column: "AccountUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AccountUserId",
                table: "Accounts",
                column: "AccountUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_TranAccountAccountNum",
                table: "Transactions",
                column: "TranAccountAccountNum",
                principalTable: "Accounts",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AccountUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TranAccountAccountNum",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TranAccountId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AccountUserId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
