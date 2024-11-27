using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public class MuralVendasRepositorio : IMuralVendasRepositorio
    {

        private readonly BancoContext _bancoContext;


        public MuralVendasRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }



        public List<ProdutoModel> BuscarTodosProdutos()
        {
            var todosProdutos = _bancoContext.Produto.ToList();

            return todosProdutos;
        }
    }



}