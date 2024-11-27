using MercadoRaiz.Models;
using MercadoRaiz.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace MercadoRaiz.Repositorio
{
    

    public class CarrinhoRepositorio : ICarrinhoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CarrinhoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void AdicionarAoCarrinho(CarrinhoItemModel item)
        {
            _bancoContext.CarrinhoItem.Add(item);
            _bancoContext.SaveChanges();
        }

        public List<CarrinhoItemModel> ListarItensNoCarrinho(string cpfCliente)
        {
            return _bancoContext.CarrinhoItem
                                .Where(ci => ci.CPF_Cliente == cpfCliente)
                                .ToList();
        }

        public void RemoverDoCarrinho(int id)
        {
            var item = _bancoContext.CarrinhoItem.Find(id);
            if (item != null)
            {
                _bancoContext.CarrinhoItem.Remove(item);
                _bancoContext.SaveChanges();
            }
        }

        public void LimparCarrinho(string cpfCliente)
        {
            var itens = _bancoContext.CarrinhoItem
                                     .Where(ci => ci.CPF_Cliente == cpfCliente)
                                     .ToList();
            _bancoContext.CarrinhoItem.RemoveRange(itens);
            _bancoContext.SaveChanges();
        }
    }
}
