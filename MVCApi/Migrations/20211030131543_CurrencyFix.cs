using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApi.Migrations
{
    public partial class CurrencyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currency_CurrencyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CurrencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Currency_CurrencyId",
                table: "Products",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
