
using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MercadoRaiz.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;//fazendo a injeção de dependencia
    private readonly IProdutoRepositorio _produtoRepositorio;//fazendo a injeção de dependencia

    public LoginController(IUsuarioRepositorio UsuarioRepositorio, IProdutoRepositorio ProdutoRepositorio)
    {

        _usuarioRepositorio = UsuarioRepositorio;
        _produtoRepositorio = ProdutoRepositorio;
    }
    

    //VISUALIZAÇÃO
    public IActionResult Index()
    {
        return View();
    }






[HttpPost]
public async Task<IActionResult> ChecarLogin(string cpfdigitado, string senhadigitada, string returnUrl = null)
{
    
        cpfdigitado = new string(cpfdigitado.Where(char.IsDigit).ToArray()); 
        

try {
  
    var resultado = _usuarioRepositorio.LoginUsuario(cpfdigitado, senhadigitada);
    var tipousuario = _usuarioRepositorio.TipoUsuario(cpfdigitado);

    if (resultado)
    {
        // Criar os claims de usuário
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, cpfdigitado),
            new Claim(ClaimTypes.Role, tipousuario) // Atribuir a role com base no tipo de usuário
        };

        // Criar a identidade do usuário
        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        // Definir as propriedades de autenticação
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, // Manter o usuário logado mesmo após fechar o navegador
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1), // Expirar após 1 hora
            RedirectUri = returnUrl // Redirecionar para a URL de retorno após o login
        };

        // Fazer login do usuário
        await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

        // Verificar se existe um ReturnUrl
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        // Redirecionar para as páginas específicas dos usuários
        if (tipousuario == "Produtor")
        {
            
            return RedirectToAction("Index", "InterfaceProdutor");
        }
        if (tipousuario == "Cliente"){

            
        } return RedirectToAction("Index", "InterfaceCliente");
    }
        
    
  }catch (Exception ex) {

    
    ViewBag.ErrorMessage1 = "CPF ou senha inválidos.";
    
  }
    ViewBag.ErrorMessage2 = "CPF ou senha inválidos.";
    ViewBag.resultado = false;
    return View("Index");

}

  [HttpGet]
    public IActionResult EsqueciSenha()
    {
        return View();
    }

   [HttpPost]
public IActionResult EsqueciSenha(string cpf, string novaSenha, string confirmarSenha)
{
    cpf = new string(cpf.Where(char.IsDigit).ToArray());

    if (novaSenha != confirmarSenha)
    {
        ViewBag.ErrorMessage = "As senhas não coincidem.";
        return View();
    }

    var usuario = _usuarioRepositorio.BuscarPorCPF(cpf);
    if (usuario == null)
    {
        ViewBag.ErrorMessage = "CPF não cadastrado.";
        return View();
    }

    _usuarioRepositorio.AtualizarSenha(cpf, novaSenha);
    ViewBag.Sucesso = "Senha alterada com sucesso.";
    return RedirectToAction("Index");
}





}




















































  

