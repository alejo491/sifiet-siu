using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SIFIET.GestionProgramas.Datos.Modelo;

namespace SIFIET.GestionProgramas.Dominio.Servicios
{
    class ServicioProgramas
    {
        private static GestionProgramasEntities db = new GestionProgramasEntities();

        public static List<PROGRAMA> ConsultarProgramas()
        {
            return db.PROGRAMAs.ToList();
        }

        public static PROGRAMA ConsultarPrograma(string id)
        {
            PROGRAMA programa = db.PROGRAMAs.Find(id);
            return programa;
        }

        public static List<PROGRAMA> ConsultarProgramaPorNombre(string busqueda)
        {
            var programas = from m in db.PROGRAMAs
                            select m;

            if (!String.IsNullOrEmpty(busqueda))
            {
                programas = programas.Where(s => s.NOMPROGRAMA.Contains(busqueda));
            }

            return programas.ToList();
        }

        public static bool RegistrarPrograma(PROGRAMA programa)
        {
            try
            {
                db.PROGRAMAs.Add(programa);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static bool EditarPrograma(PROGRAMA programa)
        {
            try
            {
                var original = ConsultarPrograma(programa.IDPROGRAMA);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(programa);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool EliminarPrograma(PROGRAMA programa)
        {
            try
            {
                db.PROGRAMAs.Remove(programa);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static void CargarDatos(DataSet datosExcel)
        {
            if (datosExcel != null)
            {
                for (int i = 0; i < datosExcel.Tables[0].Rows.Count; i++)
                {
                    PROGRAMA programa = new PROGRAMA();
                    programa.IDPROGRAMA = datosExcel.Tables[0].Rows[i][0].ToString();
                    programa.IDFACULTAD = datosExcel.Tables[0].Rows[i][1].ToString();
                    programa.NOMPROGRAMA = datosExcel.Tables[0].Rows[i][2].ToString();
                    programa.DESCPROGRAMA = datosExcel.Tables[0].Rows[i][3].ToString();
                    programa.JORNANADAPROGRAMA = datosExcel.Tables[0].Rows[i][4].ToString();
                    programa.DURACIONPROGRAMA = decimal.Parse(datosExcel.Tables[0].Rows[i][5].ToString());
                    programa.ADMISIONPROGRAMA = datosExcel.Tables[0].Rows[i][6].ToString();
                    programa.CODIGOSNIES = decimal.Parse(datosExcel.Tables[0].Rows[i][7].ToString());
                    programa.PERIODODURACION = datosExcel.Tables[0].Rows[i][8].ToString();
                    programa.ESTADOPROGRAMA = datosExcel.Tables[0].Rows[i][9].ToString();
                    db.PROGRAMAs.Add(programa);
                    db.SaveChanges();
                }
            }
        }
    }
}
