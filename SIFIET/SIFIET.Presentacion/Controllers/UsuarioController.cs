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
            FachadaSIFIET.RegistrarUsuario(datos["IDUSUARIO"], datos["EMAILINSTITUCIONALUSUARIO"],
                datos["PASSWORDUSUARIO"], int.Parse(datos["IDENTIFICACIONUSUARIO"]), datos["NOMBRESUSUARIO"],
                datos["APELLIDOSUSUARIO"], "false");
                ViewBag.Mensaje = "false";

            return RedirectToAction("Index");
        }

        public ActionResult VisualizarUsuario(string idUsuario)
        {
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        public ActionResult ModificarUsuario(string idUsuario)
        {
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarUsuario([Bind(Include = "IDUSUARIO,EMAILINSTITUCIONALUSUARIO,PASSWORDUSUARIO,IDENTIFICACIONUSUARIO,NOMBRESUSUARIO,APELLIDOSUSUARIO,ESTADO")] USUARIO usuario)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.ModificarUsuario(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult EliminarUsuario(string idUsuario)
        {
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        [HttpPost, ActionName("EliminarUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string idUsuario)
        {
            FachadaSIFIET.EliminarUsuario(idUsuario);
            return RedirectToAction("Index");
        }

    }
}
