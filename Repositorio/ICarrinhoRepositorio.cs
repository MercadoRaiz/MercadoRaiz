using MercadoRaiz.Models;
using MercadoRaiz.Configuration;

namespace MercadoRaiz.Repositorio
{

public interface ICarrinhoRepositorio
    {
        void AdicionarAoCarrinho(CarrinhoItemModel item);
        List<CarrinhoItemModel> ListarItensNoCarrinho(string cpfCliente);
        void RemoverDoCarrinho(int id);
        void LimparCarrinho(string cpfCliente);
    }
}
