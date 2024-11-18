using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MercadoRaiz.Controllers;

[Authorize(Policy = "Produtor")]
public class InterfaceProdutorController : Controller
{
    private readonly IProdutoRepositorio _produtoRepositorio;//fazendo a injeção de dependencia

    public InterfaceProdutorController(IProdutoRepositorio produtoRepositorio)
     {

         _produtoRepositorio = produtoRepositorio;
     }

//VISUALIZAÇÃO
    public IActionResult Index()
    {
        return View();
    }

     public IActionResult CadastrarPage()
    {
        return View();
    }


     public IActionResult GerenciarProdutosPage(ProdutoModel produto)
    {

        produto.CPF_Produtor = GetCPF(produto);
        List<ProdutoModel> produtos = _produtoRepositorio.BuscarProdutos(produto.CPF_Produtor);


        return View(produtos);

    }


    public IActionResult AtualizarProduto()
    {

        return View();
    }




    [HttpPost]
    public ActionResult CadastrarProduto(ProdutoModel produto)
    {
        
        produto.CPF_Produtor = GetCPF(produto);
        
        _produtoRepositorio.Adicionar(produto);
        return RedirectToAction("Index");
    }


    public IActionResult EditarProdutosPage(int id)
{
   
    ProdutoModel produto = _produtoRepositorio.ListarProduto(id);
    return View(produto);
}


    [HttpPost]
    public IActionResult AtualizarProduto(ProdutoModel produto)
    {


        _produtoRepositorio.Atualizar(produto);
        return RedirectToAction("GerenciarProdutosPage");
    }


  
    // public IActionResult RemoverProduto(int id)
    // {
    //   ProdutoModel produto = _produtoRepositorio.ListarProduto(id);   
    //     return View(produto);
    // }

     public IActionResult Remover(int id)
    {
         _produtoRepositorio.Remover(id);

        return RedirectToAction("GerenciarProdutosPage"); //redireciona para index

    }





    public string GetCPF(ProdutoModel produto){

    var cpfProdutor = User.FindFirst(ClaimTypes.Name)?.Value;
    produto.CPF_Produtor = cpfProdutor;

    return produto.CPF_Produtor;

    }

    

}