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
    public class PlanCobroController : Controller
    {
        public ActionResult Index()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> list;
            try
            {
                list = _ServicePlanCobro.GetPlanesCobro();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult Details(int id)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            PlanCobro plan;
            try
            {
                plan = _ServicePlanCobro.GetPlanCobroByID(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Details";
                return RedirectToAction("Default", "Error");
            }
            return View(plan);
        }

        public ActionResult Create()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            ViewBag.listaRubros = ListaRubros();
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            ServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            try
            {
                PlanCobro plan = _ServicePlanCobro.GetPlanCobroByID(id);
                ViewBag.listaRubros = ListaRubros(plan.Rubro);
                return View(plan);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No se pudo editar el libro deseado" + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        public ActionResult Save(PlanCobro plan, int[] listaRubros)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            try
            {
                if (ModelState.IsValid)
                {
                    PlanCobro oPlan = _ServicePlanCobro.Save(plan, listaRubros);
                }
                else
                {
                    Util.ValidateErrors(this);
                    ViewBag.listaRubros = ListaRubros();
                    if (plan.ID > 0) return View("Edit", plan);
                    else return View("Create", plan);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanCobro";
                TempData["Redirect-Action"] = "Create";
                return RedirectToAction("Default", "Error");
            }
        }

        private MultiSelectList ListaRubros(ICollection<Rubro> rubros = null)
        {
            IServiceRubro _ServiceRubro = new ServiceRubro();
            IEnumerable<Rubro> lista = _ServiceRubro.GetRubros();
            int[] selectedRubros = null;
            if (rubros != null) selectedRubros = rubros.Select(r => r.ID).ToArray();
            return new MultiSelectList(lista, "ID", "Motivo", selectedRubros);
        }

    }
}