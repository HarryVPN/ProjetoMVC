using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Enums;
using MeuSiteEmMVC.Models;

using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class UserController(BancoContext bancoContext) : Controller
    {
        private readonly BancoContext _bancoContext = bancoContext;

        private UserModel BuscarPorId(int id)
        {
            UserModel? contato = _bancoContext.Users.FirstOrDefault(x => x.Id == id);

            if (contato == null) { throw new System.Exception("Id de contato nulo"); }
            return contato;
        }

        //
        public IActionResult Index()
        {
            return View(_bancoContext.Users.ToList());
        }

        public IActionResult Editar(int id)
        {
            return View(BuscarPorId(id));
        }

        //
        private bool EditarUser(UserModel user)
        {
            if (user==null || user.Email==null || !Enum.IsDefined(user.Cargo)) { 
                return false; 
            }
            _bancoContext.Users.Update(user);
            _bancoContext.SaveChanges();
            return true;
        }
        
        [HttpPost]public IActionResult Editar(UserModel user)
        {
            if (ModelState.IsValid && EditarUser(user))
            {
                TempData[IDsTempData.SucessoAddContato] = $"Contato #{user.Id} ({user.Nome}) foi Alterado";
                return RedirectToAction("Index");
            }
            return View("Editar", user);
        }
    }
}
