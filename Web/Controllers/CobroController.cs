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
using Web.Utils;
using System.Globalization;

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

        public ActionResult AdminIndex()
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
                TempData["Redirect-Action"] = "AdminIndex";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult AdminDetails(int idResidencia)
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
                TempData["Redirect-Action"] = "AdminDetails";
                return RedirectToAction("Default", "Error");
            }
            return View(estado);
        }

        public ActionResult AdminCreate(int idResidencia)
        {
            try
            {
                ViewBag.listaPlanes = ListaPlanes();
                return View(idResidencia);
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

        public ActionResult Save(string fecha, int planSelected, int idResidencia)
        {
            IServiceEstadoCuenta _ServiceEstadoCuenta = new ServiceEstadoCuenta();
            IServiceCobro _ServiceCobro = new ServiceCobro();
            EstadoCuenta estado;
            try
            {
                estado = _ServiceEstadoCuenta.GetEstadoCuentaFromResidencia(idResidencia);
                DateTime date = DateTime.ParseExact(fecha, "MM-yyyy", CultureInfo.InvariantCulture);
                bool monthIsFree = estado.Cobros.Find(cobro => cobro.fecha.Month == date.Month) == null;
                if (ModelState.IsValid && monthIsFree)
                {
                    _ServiceCobro.CreateCobro(date, planSelected, idResidencia);
                }
                else
                {
                    if (!monthIsFree) ModelState.AddModelError("Cobro.fecha", "Ya existe un cobro para el mes solicitado");
                    Util.ValidateErrors(this);
                    ViewBag.listaPlanes = ListaPlanes();
                    return View("AdminCreate", idResidencia);
                }
                return RedirectToAction("AdminIndex");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Cobro";
                TempData["Redirect-Action"] = "AdminIndex";
                return RedirectToAction("Default", "Error");
            }
        }

        private SelectList ListaPlanes(PlanCobro plan = null)
        {
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> lista = _ServicePlanCobro.GetPlanesCobro();
            int selected = 0;
            if (plan != null) selected = plan.ID;
            return new SelectList(lista, "ID", "nombre", selected);
        }

    }
}