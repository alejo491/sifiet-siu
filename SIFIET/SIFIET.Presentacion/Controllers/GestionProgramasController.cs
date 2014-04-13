using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFIET.Aplicacion;




namespace SIFIET.Presentacion.Controllers
{
    public class GestionProgramasController : Controller
    {

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View(FachadaSIFIET.ConsultarAsignaturas());
        }
        public ActionResult Details(string idAsignatura)
        {
            return View(FachadaSIFIET.ConsultarAsignatura(idAsignatura));
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarAsignatura(FormCollection datos)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.RegistrarAsignatura(datos["IDASIGNATURA"], datos["IDPLANESTUDIOS"], datos["NOMADIGNATURA"], datos["CORREQUISITOSASIGNATURA"], datos["PREREQUISITOSASIGNATURA"], short.Parse(datos["SEMESTREASIGNATURA"]),short.Parse(datos["INTENSIDADHORARIA"]),datos["MODALIDAD"],datos["CLASIFICACION"],datos["ESTADOASIGNATURA"]);
            ViewBag.Mensaje = "false";
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string idAsignatura)
        {
            
            return View(FachadaSIFIET.ConsultarAsignatura(idAsignatura));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection datos)
        {
            if (!ModelState.IsValid) return View();
            FachadaSIFIET.ActualizarAsignatura(datos["IDASIGNATURA"], datos["IDPLANESTUDIOS"], datos["NOMADIGNATURA"], datos["CORREQUISITOSASIGNATURA"], datos["PREREQUISITOSASIGNATURA"], short.Parse(datos["SEMESTREASIGNATURA"]), short.Parse(datos["INTENSIDADHORARIA"]), datos["MODALIDAD"], datos["CLASIFICACION"], datos["ESTADOASIGNATURA"]);
            ViewBag.Mensaje = "false";

            return RedirectToAction("Index");
        }
        

        public ActionResult Delete(string idAsignatura)
        {
            return View(FachadaSIFIET.ConsultarAsignatura(idAsignatura));
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string idAsignatura)
        {
            FachadaSIFIET.EliminarAsignatura(idAsignatura);
            return RedirectToAction("Index");
        }
    }

}