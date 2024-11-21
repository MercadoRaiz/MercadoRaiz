

using System;

namespace MercadoRaiz.Models
{
    public class CarrinhoItemModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }
        public string CPF_Cliente { get; set; }
    }
}



