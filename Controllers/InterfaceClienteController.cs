using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Models;
using MercadoRaiz.Repositorio;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MercadoRaiz.Controllers;


[Authorize(Policy = "Cliente")]
public class InterfaceClienteController : Controller
{
   
    private readonly IProdutoRepositorio _produtoRepositorio;//fazendo a injeção de dependencia
    private readonly IPedidoRepositorio _pedidoRepositorio;


    public InterfaceClienteController(IPedidoRepositorio pedidoRepositorio)
     {
        _pedidoRepositorio = pedidoRepositorio;
         
        
     }
//VISUALIZAÇÃO
    public IActionResult Index()
    {
        return View();
    }

     public IActionResult RelatorioComprasPage() {
        var cpfCliente = GetCPFCliente(); 
        List<PedidoModel> pedidos = _pedidoRepositorio.BuscarPedidosPorCliente(cpfCliente); 
        return View(pedidos); }





 private string GetCPFCliente()
        {
            var cpfCliente = User.FindFirst(ClaimTypes.Name)?.Value;
            return cpfCliente;
        }

        }