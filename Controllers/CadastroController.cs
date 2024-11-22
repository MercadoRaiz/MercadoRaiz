using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;

namespace MercadoRaiz.Controllers;

public class CadastroController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia

    public CadastroController(IUsuarioRepositorio UsuarioRepositorio)
    {

        _usuarioRepositorio = UsuarioRepositorio;
    }

    //VISUALIZAÇÃO
    public IActionResult Index()
    {
        return View();
    }


    //VISUALIZAÇÃO
    public IActionResult CadastroPage()
    {


        return View();
    }



    //METODO
    [HttpPost]
    public IActionResult CadastrarUsuario(UsuarioModel usuario)
    {
       
        _usuarioRepositorio.CadastrarUsuario(usuario);
        return RedirectToAction("Index", "Login");

    }









}

