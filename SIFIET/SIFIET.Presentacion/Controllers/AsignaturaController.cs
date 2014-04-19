using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            ViewBag.correquisitos = FachadaSIFIET.ConsultarCorrequisitos();
            if (ViewBag.correquisitos == null)
            {
                ViewBag.ErrorCorrequisitos = "*";
            }
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

        public ActionResult CargarArchivo()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo)
        {
            Boolean fileOK = false;
            String fileExtension = Path.GetExtension(archivo.FileName).ToLower();
            String[] allowedExtensions = { ".xls" , ".xlsx"};
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }

            DataTable dt = new DataTable();
            DataTable aux = new DataTable();
            DataTable det = new DataTable();
            if (fileOK)
            {
                string fn = Path.GetFileName(archivo.FileName);
                string filePath = Server.MapPath(@"~\Uploads") + "\\" + fn;
                archivo.SaveAs(filePath);

                using (OleDbConnection cn = new OleDbConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        if (fileExtension == ".xls")
                        {
                            cn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                                                  ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
                        }
                        if (fileExtension == ".xlsx")
                        {
                            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + 
                                                    ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }

                        cn.Open();
                        aux = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        List<string> listhojas = new List<string>();
                        foreach (DataRow row in aux.Rows)
                        {
                            listhojas.Add(row["TABLE_NAME"].ToString());
                        }

                        cmd.Connection = cn;
                        List<int> validador = new List<int>();
                        foreach (string hoja in listhojas)
                        {
                            cmd.CommandText = "Select * from [" + hoja + "]";
                            using (OleDbDataAdapter adpaux = new OleDbDataAdapter(cmd))
                            {
                                adpaux.Fill(det);
                            }
                            if (det.Columns.Count > 1)
                            {
                                validador.Add(1);
                            }
                            else
                            {
                                validador.Add(0); 
                            }
                            cmd.CommandText = "";
                            det.Reset();
                        }

                        int unelemento = 0;
                        for (int j = 0; j < validador.Count ; j++)
                        {
                            unelemento = unelemento + validador[j];
                        }

                        string consulta = "";
                        int i = 0;
                        foreach (string hoja in listhojas)
                        {
                            if (unelemento == 1 && validador[i] == 1)
                            {
                                consulta = consulta + "Select * from [" + hoja + "]";
                            }
                            else
                            {
                                if (!listhojas.Last().Equals(hoja) && validador[i] == 1)
                                {
                                    consulta = consulta + "Select * from [" + hoja + "] union ";
                                }
                                else if (validador[i] == 1)
                                {
                                    consulta = consulta + "Select * from [" + hoja + "]";
                                }
                            }
                            i++;
                        }
                        cmd.CommandText = consulta;
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                        }
                    }
                    cn.Close();
                }
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            Session["DatosSession"] = ds;
            return RedirectToAction("CargarInformacion");
        }

        public ActionResult CargarInformacion()
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["DatosSession"];
            return View(ds);
        }

        public ActionResult EnviarDatos()
        {
            DataSet ds = new DataSet();
            ds = (DataSet) Session["DatosSession"];
            using (
                   StreamWriter wr = new StreamWriter(
                        @"~\Uploads\file.txt")
                                    )
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    wr.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + row[3] + "," + row[4] +
                                 "," + row[5] + "," + row[6] + "," + row[7] + "," + row[8] + "," +
                                 row[9]);
                }
            }
            Session.Remove("DatosSession");
            int retorno =
                FachadaSIFIET.CargarInformacion(@"~\Uploads\file.txt");
                    if (retorno == 0)
                    {
                        Session["UpSession"] = "El archivo se cargo correctamente.";
                        return RedirectToAction("ConsultarAsignaturas");
                    }
                    Session["UpSession"] = "El archivo no se cargo correctamente.";
            return RedirectToAction("ConsultarAsignaturas");

        }

    }

}