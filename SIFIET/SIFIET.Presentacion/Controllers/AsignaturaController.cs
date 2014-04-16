using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
             ViewData["Mensaje"] = Session["varsession"];
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

        public ActionResult CargarInformacion()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CargarInformacion(HttpPostedFileBase archivo)
        {
            Boolean fileOK = false;
            String fileExtension = Path.GetExtension(archivo.FileName).ToLower();
            String[] allowedExtensions = { ".xls" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }

            if (fileOK)
            {
                string fn = Path.GetFileName(archivo.FileName);
                string filePath = Server.MapPath(@"~\Uploads") + "\\" + fn;
                archivo.SaveAs(filePath);
                String path = Server.MapPath("~/UploadedImages/");

                    using (OleDbConnection cn = new OleDbConnection())
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            cn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                                                  ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
                            cmd.Connection = cn;
                            cmd.CommandText = "select * from [Hoja1$]";

                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adp.Fill(dt);
                                using (
                                    StreamWriter wr =
                                        new StreamWriter(
                                            @"C:\InfoAlex\Windows 8.1\Proyecto II\Aplicacion\SIFIET.Presentacion\Uploads\file.txt")
                                    )
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        wr.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + row[3] + "," + row[4] +
                                                     "," + row[5] + "," + row[6] + "," + row[7] + "," + row[8] + "," +
                                                     row[9]);
                                    }
                                }
                            }
                        }
                    }
                    int retorno =
                        FachadaSIFIET.CargarInformacion(@"C:\InfoAlex\Windows 8.1\Proyecto II\Aplicacion\SIFIET.Presentacion\Uploads\file.txt");
                    if (retorno == 0)
                    {
                        Session["varsession"] = "El archivo se cargo correctamente.";
                        return RedirectToAction("ConsultarAsignaturas");
                    }
                } 
                Session["varsession"] = "El archivo no se cargo correctamente o no corresponde a un archivo excel.";
                return RedirectToAction("ConsultarAsignaturas");
        }

    }

}