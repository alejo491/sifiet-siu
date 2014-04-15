using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFIET.Aplicacion;
using SIFIET.GestionProgramas.Datos.Modelo;





namespace SIFIET.Presentacion.Controllers
{
    public class AsignaturaController : Controller
    {

        //
        // GET: /Usuario/

        public ActionResult ConsultarAsignaturas(string palabraBusqueda)
        {
            return View(FachadaSIFIET.ConsultarAsignaturas(palabraBusqueda));
        }
        public ActionResult RegistrarAsignatura()
        {
            return View();
        }
        public ActionResult VisualizarAsignatura(string idAsignatura)
        {
            return View(FachadaSIFIET.VisualizarAsignatura(idAsignatura));
        }
        public ActionResult ModificarAsignatura(string idAsignatura)
        {

            return View(FachadaSIFIET.VisualizarAsignatura(idAsignatura));
        }
        public ActionResult EliminarAsignatura(string idAsignatura)
        {
            return View(FachadaSIFIET.VisualizarAsignatura(idAsignatura));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarAsignatura(ASIGNATURA datos)
        {
            if (!ModelState.IsValid) return View(datos);
            FachadaSIFIET.RegistrarAsignatura(datos.IDASIGNATURA, datos.IDPLANESTUDIOS, datos.NOMADIGNATURA,
                datos.CORREQUISITOSASIGNATURA, datos.PREREQUISITOSASIGNATURA, datos.SEMESTREASIGNATURA,
                datos.INTENSIDADHORARIA, datos.MODALIDAD, datos.CLASIFICACION, datos.ESTADOASIGNATURA);
            //FachadaSIFIET.RegistrarAsignatura(datos["IDASIGNATURAv"], datos["IDPLANESTUDIOS"], datos["NOMADIGNATURA"], datos["CORREQUISITOSASIGNATURA"], datos["PREREQUISITOSASIGNATURA"], short.Parse(datos["SEMESTREASIGNATURA"]), short.Parse(datos["INTENSIDADHORARIA"]), datos["MODALIDAD"], datos["CLASIFICACION"], datos["ESTADOASIGNATURA"]);
            ViewBag.Mensaje = "false";

            return RedirectToAction("ConsultarAsignaturas");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarAsignatura(ASIGNATURA datos)
        {
            if (!ModelState.IsValid) return View();
            //FachadaSIFIET.ModificarAsignatura(datos["IDASIGNATURA"], datos["IDPLANESTUDIOS"], datos["NOMADIGNATURA"], datos["CORREQUISITOSASIGNATURA"], datos["PREREQUISITOSASIGNATURA"], short.Parse(datos["SEMESTREASIGNATURA"]), short.Parse(datos["INTENSIDADHORARIA"]), datos["MODALIDAD"], datos["CLASIFICACION"], datos["ESTADOASIGNATURA"]);
            FachadaSIFIET.ModificarAsignatura(datos.IDASIGNATURA, datos.IDPLANESTUDIOS, datos.NOMADIGNATURA,
                datos.CORREQUISITOSASIGNATURA, datos.PREREQUISITOSASIGNATURA, datos.SEMESTREASIGNATURA,
                datos.INTENSIDADHORARIA, datos.MODALIDAD, datos.CLASIFICACION, datos.ESTADOASIGNATURA);
            ViewBag.Mensaje = "false";

            return RedirectToAction("ConsultarAsignaturas");
        }




        [HttpPost, ActionName("EliminarAsignatura")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarAsignaturaConfirmacion(string idAsignatura)
        {
            FachadaSIFIET.EliminarAsignatura(idAsignatura);
            return RedirectToAction("ConsultarAsignaturas");
        }
    }

}