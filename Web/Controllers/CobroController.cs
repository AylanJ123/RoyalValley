using ApplicationCore.Services;
using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.DTOS;

namespace RoyaltyValley.Controllers
{
    public class CobroController : Controller
    {
        public ActionResult Index()
        {
            IServiceEstadoCuenta _ServiceEstadoCuenta = new ServiceEstadoCuenta();
            IEnumerable<EstadoCuenta> list;
            try
            {
                list = _ServiceEstadoCuenta.GetEstadosCuenta();
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

        public ActionResult Details(int idResidencia)
        {
            IServiceEstadoCuenta _ServiceEstadoCuenta = new ServiceEstadoCuenta();
            EstadoCuenta estado;
            try
            {
                estado = _ServiceEstadoCuenta.GetEstadoCuentaFromResidencia(idResidencia);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Cobro";
                TempData["Redirect-Action"] = "Details";
                return RedirectToAction("Default", "Error");
            }
            return View(estado);
        }
    }
}