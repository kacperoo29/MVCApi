using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApi.Migrations
{
    public partial class FixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyProduct_Currency_CurrencyId",
                table: "CurrencyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyProduct_Products_ProductId",
                table: "CurrencyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Products_ProductId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_ShoppingCarts_ShoppingCartId",
                table: "ProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyProduct",
                table: "CurrencyProduct");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyProduct_CurrencyId",
                table: "CurrencyProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCart");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductCart");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CurrencyProduct");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CurrencyProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShoppingCartId",
                table: "ProductCart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "ProductCart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CurrencyProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CurrencyProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart",
                columns: new[] { "ProductId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyProduct",
                table: "CurrencyProduct",
                columns: new[] { "CurrencyId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyProduct_Currency_CurrencyId",
                table: "CurrencyProduct",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyProduct_Products_ProductId",
                table: "CurrencyProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Products_ProductId",
                table: "ProductCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_ShoppingCarts_ShoppingCartId",
                table: "ProductCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyProduct_Currency_CurrencyId",
                table: "CurrencyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyProduct_Products_ProductId",
                table: "CurrencyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Products_ProductId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_ShoppingCarts_ShoppingCartId",
                table: "ProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyProduct",
                table: "CurrencyProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShoppingCartId",
                table: "ProductCart",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "ProductCart",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductCart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductCart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CurrencyProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CurrencyProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CurrencyProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CurrencyProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyProduct",
                table: "CurrencyProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyProduct_CurrencyId",
                table: "CurrencyProduct",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyProduct_Currency_CurrencyId",
                table: "CurrencyProduct",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyProduct_Products_ProductId",
                table: "CurrencyProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Products_ProductId",
                table: "ProductCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_ShoppingCarts_ShoppingCartId",
                table: "ProductCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
