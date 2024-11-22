using Microsoft.AspNetCore.Mvc;
using MercadoRaiz.Repositorio;
using MercadoRaiz.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MercadoRaiz.Controllers
{
    public class MuralVendasController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMuralVendasRepositorio _muralvendasRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly ICarrinhoRepositorio _carrinhoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public MuralVendasController(IMuralVendasRepositorio muralVendasRepositorio, IProdutoRepositorio produtoRepositorio, IPedidoRepositorio pedidoRepositorio, ICarrinhoRepositorio carrinhoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _muralvendasRepositorio = muralVendasRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _carrinhoRepositorio = carrinhoRepositorio;
        }

        // VISUALIZAÇÃO
        public IActionResult Index()
        {
            List<ProdutoModel> resultado_lista = _muralvendasRepositorio.BuscarTodosProdutos();
            ViewBag.TipoUsuario = GetTipoUsuario();
            return View(resultado_lista);
            
        }

        public IActionResult ComprarPage(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarProduto(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado na página de compra.");
            }
            return View(produto);
        }

        // Processar a compra
        [HttpPost]
        public IActionResult ComprarProduto([FromForm] int Id_Produto, int quantidadeComprada)
        {
            // Adicionando logs de depuração
            Console.WriteLine($"ID do Produto: {Id_Produto}");
            Console.WriteLine($"Quantidade Comprada: {quantidadeComprada}");

            ProdutoModel produto = _produtoRepositorio.ListarProduto(Id_Produto);
            if (produto == null)
            {
                return NotFound("Produto não encontrado no método ComprarProduto.");
            }

            if (produto.Estoque >= quantidadeComprada)
            {
                produto.Estoque -= quantidadeComprada;
                _produtoRepositorio.Atualizar(produto);

                // Obter o CPF do cliente
                var cpfCliente = GetCPFCliente();

                decimal valorTotal = produto.Valor * quantidadeComprada;
                _pedidoRepositorio.CriarPedido(produto.Id_Produto, valorTotal, cpfCliente, produto.CPF_Produtor, quantidadeComprada, produto.Nome.ToString());

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Estoque insuficiente.");
            }

            return View("ComprarPage", produto);
        }

        // Adicionar item ao carrinho
        [HttpPost]
        public IActionResult AdicionarCarrinho(int id, int quantidade)
        {
            var produto = _produtoRepositorio.ListarProduto(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            var cpfCliente = GetCPFCliente();

            var itemCarrinho = new CarrinhoItemModel
            {
                ProdutoId = produto.Id_Produto,
                Produto = produto,
                Quantidade = quantidade,
                CPF_Cliente = cpfCliente
            };

            _carrinhoRepositorio.AdicionarAoCarrinho(itemCarrinho);

            return RedirectToAction("Index");
        }

        // Visualizar itens no carrinho
        public IActionResult CarrinhoPage()
        {
            var cpfCliente = GetCPFCliente();
            var itensCarrinho = _carrinhoRepositorio.ListarItensNoCarrinho(cpfCliente);

            // Carregar dados completos do produto
            foreach (var item in itensCarrinho)
            {
                item.Produto = _produtoRepositorio.ListarProduto(item.ProdutoId);
            }

            return View(itensCarrinho);
        }

        // Remover item do carrinho
        [HttpPost]
        public IActionResult RemoverDoCarrinho(int id)
        {
            _carrinhoRepositorio.RemoverDoCarrinho(id);
            return RedirectToAction("CarrinhoPage");
        }

        // Comprar todos os itens do carrinho
        [HttpPost]
        public IActionResult ComprarCarrinho()
        {
            var cpfCliente = GetCPFCliente();
            var itensCarrinho = _carrinhoRepositorio.ListarItensNoCarrinho(cpfCliente);
            List<string> erros = new List<string>();

            foreach (var item in itensCarrinho)
            {
                var produto = _produtoRepositorio.ListarProduto(item.ProdutoId);
                if (produto == null)
                {
                    erros.Add($"Produto com ID {item.ProdutoId} não encontrado.");
                    continue;
                }

                if (produto.Estoque < item.Quantidade)
                {
                    erros.Add($"Estoque insuficiente para o produto {produto.Nome}. Estoque disponível: {produto.Estoque}, quantidade solicitada: {item.Quantidade}.");
                    continue;
                }

                produto.Estoque -= item.Quantidade;
                _produtoRepositorio.Atualizar(produto);

                decimal valorTotal = produto.Valor * item.Quantidade;
                _pedidoRepositorio.CriarPedido(produto.Id_Produto, valorTotal, cpfCliente, produto.CPF_Produtor, item.Quantidade, produto.Nome.ToString());;
            }

            if (erros.Any())
            {
                TempData["ErrosCompraCarrinho"] = erros;
                return RedirectToAction("CarrinhoPage");
            }

            _carrinhoRepositorio.LimparCarrinho(cpfCliente);
            return RedirectToAction("Index");
        }



        // Método para obter o CPF do cliente
        private string GetCPFCliente()
        {
            var cpfCliente = User.FindFirst(ClaimTypes.Name)?.Value;
            return cpfCliente;
        }

        private string GetTipoUsuario()
        {
            var tipousuario = User.FindFirst(ClaimTypes.Role)?.Value;
            return tipousuario;
        }
    }
}
