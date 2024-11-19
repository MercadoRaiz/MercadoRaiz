using MercadoRaiz.ViewModels;
using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public interface IMuralVendasRepositorio
    {
    
    List<MuralVendasViewModel> BuscarTodosProdutos();
    
}
}