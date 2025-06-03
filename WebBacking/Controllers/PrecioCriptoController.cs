using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBacking.Models;
using WebBacking.Service.IService;

namespace WebBacking.Controllers
{
    [Authorize]
    public class PrecioCriptoController : Controller
    {
        public readonly ICriptosService criptosService;

        public PrecioCriptoController(ICriptosService criptosService) 
        { 
            this.criptosService = criptosService;
        }

        /// <summary>
        /// Generar listado de criptomonedas, basado en la api.
        /// </summary>
        /// <returns></returns>
        // GET: PrecioCriptoController
        public async Task<IActionResult> Index()
        {
            string token="";
            string emailuser = "";
            ClaimsPrincipal claimuser = HttpContext.User;            

            if (claimuser.Identity.IsAuthenticated)
            {
                string cclaim;
                foreach (var claim in claimuser.Claims)
                {
                    cclaim = claim.Type;

                    if (cclaim.Substring(cclaim.LastIndexOf("/") + 1) == "emailuser")
                    {
                        emailuser = claim.Value;
                    }
                    else if (cclaim.Substring(cclaim.LastIndexOf("/") + 1) == "tokenid")
                    {
                        token = claim.Value.ToString();
                    }
                }

            }


            List<CriptoPrecioModel>  lista = await criptosService.Lista(token);

            return View(lista);
        }

        // GET: PrecioCriptoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrecioCriptoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrecioCriptoController/Create
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

        // GET: PrecioCriptoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrecioCriptoController/Edit/5
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

        // GET: PrecioCriptoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrecioCriptoController/Delete/5
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
