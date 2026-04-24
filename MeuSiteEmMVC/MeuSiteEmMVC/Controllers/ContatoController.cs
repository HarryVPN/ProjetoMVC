using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        //
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        //
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            if (_contatoRepositorio.Adicionar(contato))
                return RedirectToAction("Index");
            else
                return View();
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            if (_contatoRepositorio.Editar(contato))
                return RedirectToAction("Index");
            else
                return View();
        }

        public IActionResult Deletar(int id)
        {
            _contatoRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Esconder(int id)
        {
            _contatoRepositorio.Esconder(id);
            return RedirectToAction("Index");
        }
        
    }
}
