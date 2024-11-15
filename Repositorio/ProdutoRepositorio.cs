using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private string cpf_produtor;
        ProdutoModel produtoModel = new ProdutoModel();

        private readonly BancoContext _bancoContext;


        public ProdutoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }


        public ProdutoModel Adicionar(ProdutoModel produtos)
        {
            _bancoContext.Set<ProdutoModel>().Add(produtos); //salvar no banco de dados 
            _bancoContext.SaveChanges();

            return produtos;
        }

        public List<ProdutoModel> BuscarProdutos(string cpfProdutor)
        {
            return _bancoContext.Set<ProdutoModel>()
                                .Where(p => p.CPF_Produtor == cpfProdutor)
                                .ToList();
        }




        public ProdutoModel ListarProduto(string cpf)
        {

            return _bancoContext.Produto.FirstOrDefault(x => x.CPF_Produtor == cpf);
        }



        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarProduto(produto.CPF_Produtor);

            if (produtoDB == null) throw new Exception("Houve um erro na atualização do produto!!");
            produtoDB.Nome = produto.Nome;
            produtoDB.Estoque = produto.Estoque;
            produtoDB.Valor = produto.Valor;
            

            _bancoContext.Produto.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;



        }

        public bool Remover(string cpf)
        {
            ProdutoModel produtoDB = ListarProduto(cpf);

            if (produtoDB == null) throw new Exception("Houve um erro na Remoção do produto!!");


            _bancoContext.Produto.Remove(produtoDB);
            _bancoContext.SaveChanges();

            return true;



        }

        

      
    }
    }
