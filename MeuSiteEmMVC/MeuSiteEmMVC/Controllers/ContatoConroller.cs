using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoConroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
