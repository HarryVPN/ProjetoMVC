using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Enums;
using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace MeuSiteEmMVC.Controllers
{
    public class DenunciaController : Controller
    {

        private readonly BancoContext _bancoContext;

        public DenunciaController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        // GET: DenunciaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DenunciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DenunciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Denunciar(DenunciaModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (model.arquivoImg != null)
            {
                string nomeArquivo = Path.GetRandomFileName()+Path.GetExtension(model.arquivoImg.FileName);

                using var stream = new FileStream(
                    Path.Combine("wwwroot/images", nomeArquivo),
                    FileMode.Create);

                model.imagem = nomeArquivo;

                await model.arquivoImg.CopyToAsync(stream);
            }


            model.arquivoImg = null;
            _bancoContext.Denuncias.Update(model);
            _bancoContext.SaveChanges();

            //TempData[IDsTempData.SucessoAddContato] = $"Reportagem #{model.id} foi Adicionado";

            return RedirectToAction("Index", "Home");
        }


        // POST: DenunciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenunciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DenunciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenunciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DenunciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
