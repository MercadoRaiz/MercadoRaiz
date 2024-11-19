using MercadoRaiz.Configuration;
using MercadoRaiz.Models;
using MercadoRaiz.ViewModels;

namespace MercadoRaiz.Repositorio
{

    public class MuralVendasRepositorio : IMuralVendasRepositorio
    {

        private readonly BancoContext _bancoContext;


        public MuralVendasRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        

     public List<MuralVendasViewModel> BuscarTodosProdutos()
{
    var lista = 
        from produto in _bancoContext.Produto
        join propriedade in _bancoContext.Propriedade
        on produto.CPF_Produtor equals propriedade.CPFProdutor
        select new MuralVendasViewModel 
        {
            Id_Produto = produto.Id_Produto,
            Nome = produto.Nome.ToString(),
            Estoque = produto.Estoque,
            Valor = produto.Valor,
            Cidade = propriedade.Cidade
        };

    return lista.ToList();

    
}


            

    }
}