using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capa_Entidad;
using Capa_Negocio;
using Capa_Datos;

namespace Capa_Presentacion.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorNegocio negocio = new AdministradorNegocio();

        // GET: Login
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Correo_Administrador,string Contraseña_Administrador)
        {

            if (!string.IsNullOrEmpty(Correo_Administrador) && !string.IsNullOrEmpty(Contraseña_Administrador))
            {
                var user = negocio.Comparar(Correo_Administrador, Contraseña_Administrador);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Correo_Administrador, true);
                    return RedirectToAction("Index", "Poster");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "No encontramos tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos vacios para poder iniciar sesion" });
            }
        }

       

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Poster");
        }
    }
}