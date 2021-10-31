using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApi.Migrations
{
    public partial class ChangeCustomerScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Customers_CustomerId",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_CustomerId",
                table: "ContactInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ContactInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CustomerId",
                table: "ContactInfos",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Customers_CustomerId",
                table: "ContactInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Customers_CustomerId",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_CustomerId",
                table: "ContactInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ContactInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CustomerId",
                table: "ContactInfos",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Customers_CustomerId",
                table: "ContactInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
