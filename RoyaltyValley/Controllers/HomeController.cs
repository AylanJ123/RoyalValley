using ApplicationCore.Services;
using Infraestructure.Utils;
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
            IServiceResidencia _ServiceResidencia = new ServiceResidencia();
            IEnumerable<Residencia> list;
            try
            {
                list = _ServiceResidencia.GetResidencias();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

    }
}