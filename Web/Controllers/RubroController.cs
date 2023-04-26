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
    public class RubroController : Controller
    {
        public ActionResult Index()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServiceRubro _ServiceRubro = new ServiceRubro();
            IEnumerable<Rubro> list;
            try
            {
                list = _ServiceRubro.GetRubros();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Rubro";
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

        public ActionResult Edit(int id)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            ServiceRubro _ServiceRubro = new ServiceRubro();
            try
            {
                Rubro plan = _ServiceRubro.GetRubroByID(id);
                return View(plan);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No se pudo editar el libro deseado" + ex.Message;
                TempData["Redirect"] = "Rubro";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        public ActionResult Save(Rubro plan)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServiceRubro _ServiceRubro = new ServiceRubro();
            try
            {
                if (ModelState.IsValid)
                {
                    Rubro oPlan = _ServiceRubro.Save(plan);
                }
                else
                {
                    Util.ValidateErrors(this);
                    if (plan.ID > 0) return View("Edit", plan);
                    else return View("Create", plan);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Rubro";
                TempData["Redirect-Action"] = "Create";
                return RedirectToAction("Default", "Error");
            }
        }
    }
}