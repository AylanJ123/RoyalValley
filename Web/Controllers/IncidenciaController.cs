using ApplicationCore.Services;
using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Web.Utils;

namespace RoyaltyValley.Controllers
{
    public class IncidenciaController : Controller
    {
        public ActionResult Index()
        {
            IServiceIncidencia _ServiceIncidencia = new ServiceIncidencia();
            IEnumerable<Incidencia> list;
            try
            {
                list = _ServiceIncidencia.GetIncidencias();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Incidencia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult New(Incidencia incidencia)
        {
            ServiceIncidencia _ServiceIncidencia = new ServiceIncidencia();
            try
            {
                _ServiceIncidencia.New(incidencia);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No se pudo crear una nueva incidencia" + ex.Message;
                TempData["Redirect"] = "Incidencia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult UpdateState(int id)
        {
            ServiceIncidencia _ServiceIncidencia = new ServiceIncidencia();
            try
            {
                _ServiceIncidencia.UpdateState(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No se pudo actualizar la incidencia" + ex.Message;
                TempData["Redirect"] = "Incidencia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }
    }
}