using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;

using MeuSiteEmMVC.Enums;

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
            if (ModelState.IsValid && _contatoRepositorio.Adicionar(contato))
            {
                TempData[IDsTempData.SucessoAddContato] = $"Contato #{contato.Id} ({contato.Nome}) foi Adicionado";
                return RedirectToAction("Index");
            }   
            else
                return View();
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            if (ModelState.IsValid && _contatoRepositorio.Editar(contato))
            {
                TempData[IDsTempData.SucessoAddContato] = $"Contato #{contato.Id} ({contato.Nome}) foi Alterado";
                return RedirectToAction("Index");
            }   
            else
                return View("Editar",contato);
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
