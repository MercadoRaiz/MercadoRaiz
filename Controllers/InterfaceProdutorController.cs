using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace MercadoRaiz.Controllers;

[Authorize(Policy = "Produtor")]
public class InterfaceProdutorController : Controller
{
    // private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia

    // public InterfacesController(IUsuarioRepositorio UsuarioRepositorio)
    // {

    //     _usuarioRepositorio = UsuarioRepositorio;
    // }

//VISUALIZAÇÃO
    public IActionResult Index()
    {
        return View();
    }




}