
using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MercadoRaiz.Models;
using MercadoRaiz.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MercadoRaiz.Controllers;


// [Authorize(Policy = "Produtor")]
public class MuralVendasController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia
    private readonly IMuralVendasRepositorio _muralvendasRepositorio;//fazendo a injeção de dependencia

    public MuralVendasController(IUsuarioRepositorio UsuarioRepositorio, IMuralVendasRepositorio MuralVendasRepositorio)
    {

        _usuarioRepositorio = UsuarioRepositorio;
        _muralvendasRepositorio = MuralVendasRepositorio;
    }
    

    //VISUALIZAÇÃO


    public IActionResult Index()
    {
    


        List<MuralVendasViewModel> produtos = _muralvendasRepositorio.BuscarTodosProdutos();
        return View(produtos);
    }
}


