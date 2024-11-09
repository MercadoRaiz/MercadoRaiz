using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;

namespace MercadoRaiz.Controllers;

public class InterfacesController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia

    public InterfacesController(IUsuarioRepositorio UsuarioRepositorio)
    {

        _usuarioRepositorio = UsuarioRepositorio;
    }

//VISUALIZAÇÃO
    public IActionResult ClientePage()
    {
        return View();
    }




}
