using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;

namespace MercadoRaiz.Controllers;

public class HomeController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia

    public HomeController(IUsuarioRepositorio UsuarioRepositorio)
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
        return RedirectToAction("Index");
        
    }

  


//METODO

    //FINALIZAR!
    [HttpPost]
    public IActionResult LoginUsuario(string CPFDigitado, string senhaDigitada)
    {
       
       

        // 2. Chamar o repositório para validar o login
        bool loginValido = _usuarioRepositorio.LoginUsuario(CPFDigitado, senhaDigitada);

        if (loginValido == false)
        {
            // Se o login não for válido, mostra uma mensagem de erro
            TempData["Erro"] = "Usuário ou senha inválidos.";
            return RedirectToAction("CadastroPage");
        }

        // 3. Se o login for válido, redireciona para a página principal
        
        return RedirectToAction("ClientePage", "InterfacesController");
    }
}

