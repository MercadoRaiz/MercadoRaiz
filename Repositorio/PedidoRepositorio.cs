using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PedidoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void CriarPedido(int produtoId, decimal valorTotal, string cpfCliente, string cpfProdutor, int quantidadeComprada, string nome)
        {
            PedidoModel pedido = new PedidoModel
            {
                Data = DateTime.UtcNow,
                Valor_Total = valorTotal,
                CPF_Cliente = cpfCliente,
                CPF_Produtor = cpfProdutor,
                Estoque = quantidadeComprada,
                Produto = nome
            };

            _bancoContext.Pedido.Add(pedido);
            _bancoContext.SaveChanges();
        }


        public List<PedidoModel> BuscarPedidosPorProdutor(string cpfProdutor)
         { 
            return _bancoContext.Pedido 
                    .Where(p => p.CPF_Produtor == cpfProdutor) 
                    .ToList(); 
        }
    }
}
