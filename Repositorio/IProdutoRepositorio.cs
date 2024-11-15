using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public interface IProdutoRepositorio
    {
    

    
    public ProdutoModel Adicionar(ProdutoModel produtos);

    public List<ProdutoModel> BuscarProdutos(string cpfProdutor);

    public ProdutoModel ListarProduto(int id);

    public ProdutoModel Atualizar(ProdutoModel produto);

    public bool Remover(int id);



    


    
}
}