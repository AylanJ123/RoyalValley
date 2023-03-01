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
    public class CobroController : Controller
    {
        public ActionResult Index()
        {
            IServiceCobro _ServiceCobro = new ServiceCobro();
            IEnumerable<Cobro> list;
            try
            {
                list = _ServiceCobro.GetCobros();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Cobro";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult Details(DateTime fecha, int idResidencia, int idPlanCobro)
        {
            IServiceCobro _ServiceCobro = new ServiceCobro();
            Cobro res;
            try
            {
                res = _ServiceCobro.GetCobroByKeys(fecha, idResidencia, idPlanCobro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Cobro";
                TempData["Redirect-Action"] = "Details";
                return RedirectToAction("Default", "Error");
            }
            return View(res);
        }
    }
}