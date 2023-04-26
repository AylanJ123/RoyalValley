using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] != null) return RedirectToAction("Logout");
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult Login(string email, string pass)
        {
            if (Session["Usuario"] != null) return RedirectToAction("Logout");
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario oUsuario = null;
            try
            {
                if (email.Length > 0 && email.Length < 30 && pass.Length > 0)
                {
                    oUsuario = _ServiceUsuario.GetUsuario(email, pass);
                    if (oUsuario != null)
                    {
                        Session["Usuario"] = oUsuario;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Credenciales inválidas";
                        return View("Index");
                    }
                }
                else
                {
                    TempData["ErrorMsg"] = "Campos incompletos o correo excede 30 caracteres";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("Usuario");
            return View("Index");
        }

    }
}