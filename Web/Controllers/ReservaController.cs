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
    public class ReservaController : Controller
    {
        public ActionResult AdminIndex()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServiceReserva _ServiceReserva = new ServiceReserva();
            IEnumerable<Reserva> list;
            try
            {
                list = _ServiceReserva.GetReservas();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View(list);
        }

        public ActionResult Create()
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Resident)) return RedirectToAction("Unauthorized", "Usuario");
            ViewBag.listaEdificios = ListaEdificios();
            return View();
        }

        public ActionResult Save(Reserva reserva, int edificioId, string fecha, string hora)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Resident)) return RedirectToAction("Unauthorized", "Usuario");
            ServiceReserva _ServiceReserva = new ServiceReserva();
            try
            {
                reserva.fecha = DateTime.Parse(string.Format("{0} {1}", fecha, hora));
                IEnumerable<Reserva> reservasExistentes = _ServiceReserva.GerReservasByEdificio(edificioId);
                bool scheduleFree = true;
                (DateTime inicio, DateTime fin) tuplaHorario = (DateTime.Now, DateTime.Now);
                foreach (Reserva res in reservasExistentes)
                {
                    DateTime horaSalida = res.fecha.AddHours(res.horas);
                    DateTime horaNuevaSalida = reserva.fecha.AddHours(reserva.horas);
                    if (reserva.fecha.CompareTo(horaSalida) < 0 && reserva.fecha.CompareTo(res.fecha) > 0 || horaNuevaSalida.CompareTo(res.fecha) > 0 && reserva.fecha.CompareTo(res.fecha) < 0)
                    {
                        scheduleFree = false;
                        tuplaHorario = (res.fecha, horaSalida);
                        break;
                    }
                }
                if (ModelState.IsValid && scheduleFree)
                {
                    reserva.IDUsuario = ((Usuario) Session["Usuario"]).ID;
                    _ServiceReserva.CreateReserva(reserva, edificioId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (!scheduleFree) ModelState.AddModelError("Reserva.fecha", string.Format("Ya existe una reserva en el horario solicitado: de {0} a {1}", tuplaHorario.inicio, tuplaHorario.fin));
                    Util.ValidateErrors(this);
                    ViewBag.listaEdificios = ListaEdificios();
                    return View("Create");
                }
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

        public ActionResult UpdateState(byte estado, DateTime fecha, int idEdificio)
        {
            if (!Util.IsAuthorized(this, Util.UserAuth.Admin)) return RedirectToAction("Unauthorized", "Usuario");
            IServiceReserva _ServiceReserva = new ServiceReserva();
            try
            {
                _ServiceReserva.UpdateState(estado, fecha, idEdificio);
                return RedirectToAction("AdminIndex");
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

        private SelectList ListaEdificios(EdificioPublico edificio = null)
        {
            IServiceEdificioPublico _ServiceEdificio = new ServiceEdificioPublico();
            IEnumerable<EdificioPublico> lista = _ServiceEdificio.GetEdificios();
            int selected = 0;
            if (edificio != null) selected = edificio.ID;
            return new SelectList(lista, "ID", "Name", selected);
        }

    }
}