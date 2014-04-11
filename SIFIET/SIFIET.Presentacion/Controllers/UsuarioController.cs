using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFIET.Aplicacion;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View(FachadaSIFIET.ConsultarUsuarios());
        }

        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(FormCollection datos)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.RegistrarUsuario(datos["IDUSUARIO"], datos["EMAILINSTITUCIONALUSUARIO"], datos["PASSWORDUSUARIO"], int.Parse(datos["IDENTIFICACIONUSUARIO"]), datos["NOMBRESUSUARIO"], datos["APELLIDOSUSUARIO"], "false");
                
            return RedirectToAction("Index");
        }

    }
}
