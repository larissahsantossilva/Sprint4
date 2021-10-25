using Fiap.Challenge.Web.Models;
using Fiap.Challenge.Web.Persistencias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Challenge.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // CRIANDO UM CONTEXT NO CONTROLLER //
        LibrasContext _context;
        public ProdutoController(LibrasContext context)
        {
            _context = context;
        }

        // ACESSANDO A TELA DE CADASTRO //
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // !!! MÉTODO CADASTRAR !!!! //
        [HttpPost]
        public IActionResult Cadastrar (Produto produto)
        {
            // ADICIONANDO NO BANCO DE DADOS //
            _context.Produtos.Add(produto);
            // COMMIT //
            _context.SaveChanges();
            // MENSAGEM DE SUCESSO //
            TempData["mensagem"] = "Produto cadastrado com sucesso!";
            // REDIRECIONANDO PARA A TELA INDEX //
            return RedirectToAction("Index");
        }

        // !!! MÉTODO REMOVER !!! //
        [HttpPost]
        public IActionResult Remover (int id)
        {
            // PESQUISAR O PRODUTO A SER DELETADO PELO ID //
            var produto = _context.Produtos.Find(id);
            // REMOVENDO O PRODUTO SELECIONADO //
            _context.Produtos.Remove(produto);
            // COMMIT //
            _context.SaveChanges();
            // MENSAGEM DE SUCESSO //
            TempData["mensagem"] = "Produto removido!";
            // REDIRECIONANDO PARA A TELA INDEX //
            return RedirectToAction("Index");
        }

        // ACESSANDO A TELA DE EDIÇÃO //
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // PESQUISAR O PRODUTO SELECIONADO PELO SEU ID //
            var produto = _context.Produtos.Find(id);
            // RETORNE VIEW COM O PRODUTO SELECIONADO //
            return View(produto);
        }

        // !!! MÉTODO DE EDIÇÃO !!! //
        public IActionResult Editar(Produto produto)
        {
            // ATUALIZAR O PRODUTO SELECIONANDO NO BANCO DE DADOS //
            _context.Produtos.Update(produto);
            // COMMIT //
            _context.SaveChanges();
            // MENSAGEM DE SUCESSO //
            TempData["mensagem"] = "Produto atualizado!";
            // REDIRECIONANDO PARA A TELA INDEX //
            return RedirectToAction("Index");
        }

        // LISTAGEM DOS PRODUTOS //
        public IActionResult Index (string nome)
        {
            // FILTRAGEM DE UM PRODUTO, BUSCAR PELO SEU NOME //
            var lista = _context.Produtos.Where(p=> (p.Nome.Contains(nome) || nome == null)).ToList();
            ViewBag.produtos = lista;
            return View(lista);
        }
    }
}
