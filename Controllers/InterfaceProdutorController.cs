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


     public IActionResult GerenciarProdutosPage(string cpfProdutor)
    {


        List<ProdutoModel> produtos = _produtoRepositorio.BuscarProdutos(cpfProdutor);


        return View(produtos);

    }


    public IActionResult AtualizarProduto()
    {

        return View();
    }




    [HttpPost]
    public ActionResult CadastrarProduto(ProdutoModel produto)
    {
        var cpfProdutor = User.FindFirst(ClaimTypes.Name)?.Value;

        produto.CPF_Produtor = cpfProdutor;
        _produtoRepositorio.Adicionar(produto);
        return RedirectToAction("Index");
    }


    public IActionResult EditarProduto(string cpf)
{
    ProdutoModel produto = _produtoRepositorio.ListarProduto(cpf);
    return View(produto);
}

    [HttpPost]
    public IActionResult AtualizarProduto(ProdutoModel produto)
    {


        _produtoRepositorio.Atualizar(produto);
        return RedirectToAction("GerenciarProdutos");
    }


  
    public IActionResult RemoverProduto(string cpf)
    {
      ProdutoModel produto = _produtoRepositorio.ListarProduto(cpf);   
        return View(produto);
    }

     public IActionResult Remover(string cpf)
    {
         _produtoRepositorio.Remover(cpf);

        return RedirectToAction("GerenciarProdutos"); //redireciona para index

    }


   

}