using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoRaiz.Migrations
{
    /// <inheritdoc />
    public partial class AttTableProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPFProdutor",
                table: "Propriedade",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CPF_Produtor",
                table: "Produto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Produto",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CPF_Cliente",
                table: "Pedido",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF_Produtor",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "CPFProdutor",
                table: "Propriedade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CPF_Cliente",
                table: "Pedido",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
