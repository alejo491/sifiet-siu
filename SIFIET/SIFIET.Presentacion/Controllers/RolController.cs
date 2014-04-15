using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFIET.Aplicacion;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.Presentacion.Controllers
{
    public class RolController:Controller
    {
        public ActionResult Index()
        {
            return View(FachadaSIFIET.ConsultarRoles());
        }

        public ActionResult AgregarRol()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarRol(FormCollection datos)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.RegistrarRoles(datos["IDROL"], datos["NOMROL"],
                datos["DESCROL"],"Por Definir");
            ViewBag.Mensaje = "false";

            return RedirectToAction("Index");
        }

        public ActionResult VisualizarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        public ActionResult ModificarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarRol([Bind(Include = "IDROL,NOMROL,DESCROL")] ROL rol)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.ModificarRol(rol);
            return RedirectToAction("Index");
        }

        public ActionResult EliminarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        [HttpPost, ActionName("EliminarRol")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string idRol)
        {
            FachadaSIFIET.EliminarRol(idRol);
            return RedirectToAction("Index");
        }
    }
}