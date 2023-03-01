using ApplicationCore.Services;
using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RoyaltyValley.Controllers
{
    public class ResidenciaController : Controller
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
                TempData["Redirect"] = "Residencia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult Details(int id)
        {
            IServiceResidencia _ServiceResidencia = new ServiceResidencia();
            Residencia res;
            try
            {
                res = _ServiceResidencia.GetResidenciaByID(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Residencia";
                TempData["Redirect-Action"] = "Details";
                return RedirectToAction("Default", "Error");
            }
            return View(res);
        }

    }
}