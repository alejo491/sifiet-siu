using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Mvc;
using SIFIET.Aplicacion;
using SIFIET.GestionProgramas.Datos.Modelo;

namespace SIFIET.Presentacion.Controllers
{
    public class ProgramaController : Controller
    {
        //
        // GET: /Programa/

        public ActionResult Index(string busqueda = "")
        {
            if (busqueda == "")
            {
                return View(FachadaSIFIET.ConsultarProgramas());
            }
            return View(FachadaSIFIET.ConsultarProgramaPorNombre(busqueda));
        }

        public ActionResult AgregarPrograma()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPrograma(PROGRAMA programa)
        {
            if (ModelState.IsValid)
            {
                FachadaSIFIET.RegistrarPrograma(programa);
                return RedirectToAction("Index");
            }

            return View(programa);
        }

        //
        // GET: /Programa/Edit/5

        public ActionResult EditarPrograma(string id)
        {
            return View(FachadaSIFIET.ConsultarPrograma(id));
        }

        //
        // POST: /Programa/Edit/5

        [HttpPost]
        public ActionResult EditarPrograma(PROGRAMA programa)
        {
            if (ModelState.IsValid)
            {
                FachadaSIFIET.EditarPrograma(programa);
                return RedirectToAction("Index");
            }
            return View(programa);
        }

        //
        // GET: /Programa/Delete/5

        public ActionResult EliminarPrograma(string id)
        {
            return View(FachadaSIFIET.ConsultarPrograma(id));
        }


        [HttpPost, ActionName("EliminarPrograma")]
        public ActionResult ConfirmacionEliminarPrograma(string id)
        {
            PROGRAMA programa = FachadaSIFIET.ConsultarPrograma(id);
            FachadaSIFIET.EliminarPrograma(programa);
            return RedirectToAction("Index");
        }

        public ActionResult VisualizarPrograma(string id)
        {
            return View(FachadaSIFIET.ConsultarPrograma(id));
        }

        public ActionResult CargarDatos()
        {
            if (Request.Files.Count > 0 && Request.Files["archivo"] != null)
            {
                string rutaArchivo = Server.MapPath("~/Archivos/") + Request.Files["archivo"].FileName;
                string extencionArchivo = System.IO.Path.GetExtension(Request.Files["archivo"].FileName);
                if (extencionArchivo == ".xls" || extencionArchivo == ".xlsx")
                {
                    if (System.IO.File.Exists(rutaArchivo))
                    {
                        System.IO.File.Delete(rutaArchivo);
                    }
                    Request.Files["archivo"].SaveAs(rutaArchivo);
                    DataSet datosExcel = LeerRegistrosExcel(rutaArchivo, extencionArchivo);
                    if (datosExcel != null)
                    {
                        FachadaSIFIET.CargarDatos(datosExcel);
                        return View(datosExcel);
                    }
                    
                }


            }
            return View();
        }

        private DataSet LeerRegistrosExcel(string rutaArchivo, string extencionArchivo)
        {
            DataSet ds = new DataSet();
            string cadenaConexionExcel = string.Empty;

            if (extencionArchivo == ".xls")
            {
                cadenaConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                      rutaArchivo + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            //connection String for xlsx file format.
            else if (extencionArchivo == ".xlsx")
            {
                cadenaConexionExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                      rutaArchivo + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            OleDbConnection conexionExcel = new OleDbConnection(cadenaConexionExcel);
            conexionExcel.Open();
            DataTable dt = new DataTable();

            dt = conexionExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }

            String[] hojasExcel = new string[dt.Rows.Count];
            int iterador = 0;
            foreach (DataRow row in dt.Rows)
            {
                hojasExcel[iterador] = row["TABLE_NAME"].ToString();
                iterador++;
            }

            OleDbConnection excelConnection1 = new OleDbConnection(cadenaConexionExcel);
            string query = string.Format("Select * from [{0}]", hojasExcel[0]);
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(ds);
            }
            conexionExcel.Close();
            return ds;
        }
    }
}
