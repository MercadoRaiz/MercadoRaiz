using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoRaiz.Migrations
{
    /// <inheritdoc />
    public partial class ATT_PedidoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "Pedido",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Produto",
                table: "Pedido");
        }
    }
}
