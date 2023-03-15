using ApplicationCore.Services;
using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace RoyaltyValley.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IServiceNoticia _ServiceNoticia = new ServiceNoticia();
            IEnumerable<Noticias> list;
            try
            {
                list = _ServiceNoticia.GetNoticias();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Noticia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

    }
}