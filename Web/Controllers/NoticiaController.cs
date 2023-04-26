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
    public class NoticiaController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] == null) return RedirectToAction("Unauthorized", "Usuario");
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

        public ActionResult Create()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            return View();
        }

        public ActionResult Edit(string nombre)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            ServiceNoticia _ServiceNoticia = new ServiceNoticia();
            try
            {
                Noticias plan = _ServiceNoticia.GetNoticiaByNombre(nombre);
                return View(plan);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No se pudo editar el libro deseado" + ex.Message;
                TempData["Redirect"] = "Noticia";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        public ActionResult Save(Noticias noticia, bool edit = false)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServiceNoticia _ServiceNoticia = new ServiceNoticia();
            try
            {
                if (ModelState.IsValid)
                {
                    Noticias oPlan = _ServiceNoticia.Save(noticia);
                }
                else
                {
                    Util.ValidateErrors(this);
                    if (edit) return View("Edit", noticia);
                    else return View("Create", noticia);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Noticia";
                TempData["Redirect-Action"] = "Create";
                return RedirectToAction("Default", "Error");
            }
        }
    }
}