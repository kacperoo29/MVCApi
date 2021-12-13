using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApi.Migrations
{
    public partial class ShoppingCartState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "ShoppingCarts");
        }
    }
}
