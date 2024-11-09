namespace MercadoRaiz.Models
{


    public class PedidoModel
    {
        public int Id_Pedido { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor_Total { get; set; }
        public int CPF_Cliente { get; set; }
    }
}