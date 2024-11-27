
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public interface IPedidoRepositorio
    {
    

    
   
     public void CriarPedido(int produtoId, decimal valorTotal, string cpfCliente, string cpfProdutor, int quantidadeComprada, string nome);
     public List<PedidoModel> BuscarPedidosPorProdutor(string cpfProdutor);
     
        public List<PedidoModel> BuscarPedidosPorCliente(string cpfCliente);
        
         

    


    
}
}