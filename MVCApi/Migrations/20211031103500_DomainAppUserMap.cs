using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApi.Migrations
{
    public partial class DomainAppUserMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DomainUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_DomainUserId",
                table: "AspNetUsers",
                column: "DomainUserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DomainUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DomainUserId",
                table: "AspNetUsers");
        }
    }
}
