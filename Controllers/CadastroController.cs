using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;
using System.ComponentModel;

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

        usuario.CPF = new string(usuario.CPF.Where(char.IsDigit).ToArray()); 
        usuario.Celular = new string(usuario.Celular.Where(char.IsDigit).ToArray());

        bool resultado = _usuarioRepositorio.verificarDuplicidadeCPF(usuario.CPF);

        if (resultado == true){


             ViewBag.resultado = true;
            ViewBag.ErrorMessage = "Ja existe uma conta nesse CPF";

            return View("Index");


            
        }
        //se for estive no banco erro, se nao continuar
      
        
              _usuarioRepositorio.CadastrarUsuario(usuario);
        return RedirectToAction("Index", "Login");
           
    }









}

