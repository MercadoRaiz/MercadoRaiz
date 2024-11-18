using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoRaiz.Migrations
{
    /// <inheritdoc />
    public partial class AddEProduto_ProdutoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF_Produtor",
                table: "Pedido",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF_Produtor",
                table: "Pedido");
        }
    }
}
