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
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
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
            if (!Util.IsAuthorized(this, Util.UserAuth.Resident)) return RedirectToAction("Unauthorized", "Usuario");
            return View();
        }

        public ActionResult New(Incidencia incidencia)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Resident)) return RedirectToAction("Unauthorized", "Usuario");
            ServiceIncidencia _ServiceIncidencia = new ServiceIncidencia();
            try
            {
                incidencia.IDUsuario = ((Usuario)Session["Usuario"]).ID;
                _ServiceIncidencia.New(incidencia);
                return RedirectToAction("Index", "Home");
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
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
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