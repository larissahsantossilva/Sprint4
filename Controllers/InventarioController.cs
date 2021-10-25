using Fiap.Challenge.Web.Models;
using Fiap.Challenge.Web.Persistencias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Controllers
{
    public class InventarioController : Controller
    {

        // CRIANDO UM CONTEXT NO CONTROLLER //
        LibrasContext _context;
        public InventarioController(LibrasContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Adicionar(ItemProduto item)
        {
            _context.ItensProdutos.Add(item);
            _context.SaveChanges();
            TempData["msg"] = "Produto adicionado!";
            return RedirectToAction("Adicionar", new { id = item.InventarioId }); //Enviar o id para a action Adicionar
        }

        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            //Pesquisa o pedido 
            var pedido = _context.Inventarios.Where(p => p.InventarioId == id).FirstOrDefault();

            //Enviar os produtos para as opções do select
            //Pesquisar todos os produtos
            var lista = _context.Produtos.ToList();
            ViewBag.produtosSelect = new SelectList(lista, "ProdutoId", "Nome");

            //Enviar a lista de produtos associados ao pedido (para popular a tabela)
            ViewBag.produtos = _context.ItensProdutos
                .Where(i => i.InventarioId == id) //Filtro pelo id do pedido
                .Select(i => i.Produto) //Recuperar os produtos
                .ToList();

            return View(pedido);
        }

        // ACESSANDO A TELA DE CADASTRO //
        [HttpGet] 
        public IActionResult Cadastrar()
        {
            return View();
        }

        // !!! MÉTODO CADASTRAR !!!! //
        [HttpPost]
        public IActionResult Cadastrar(Inventario inventario)
        {
            // ADICIONANDO NO BANCO DE DADOS //
            _context.Inventarios.Add(inventario);
            // COMMIT //
            _context.SaveChanges();
            // MENSAGEM DE SUCESSO //
            TempData["mensagem"] = "Inventário cadastrado com sucesso!";
            // REDIRECIONANDO PARA A TELA INDEX //
            return RedirectToAction("Index");
        }
            
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var inventario = _context.Inventarios.Find(id);
            _context.Inventarios.Remove(inventario);
            _context.SaveChanges();
            TempData["mensagem"] = "Inventário removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var inventario = _context.Inventarios.Find(id);
            return View(inventario);
        }

        [HttpPost]
        public IActionResult Editar (Inventario inventario)
        {
            _context.Inventarios.Update(inventario);
            // COMMIT //
            _context.SaveChanges();
            // MENSAGEM DE SUCESSO //
            TempData["mensagem"] = "Produto atualizado!";
            // REDIRECIONANDO PARA A TELA INDEX //
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var lista = _context.Inventarios.ToList();
            return View(lista);
        }
    }
}
