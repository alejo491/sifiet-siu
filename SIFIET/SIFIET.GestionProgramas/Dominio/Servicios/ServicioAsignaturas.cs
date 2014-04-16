using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SIFIET.GestionProgramas.Datos.Modelo;

namespace SIFIET.GestionProgramas.Dominio.Servicios
{
    static class ServicioAsignaturas
    {
        public static List<ASIGNATURA> ConsultarAsignaturas(string palabraBusqueda)
        {
            try
            {
                var db = new GestionProgramasEntities();
                List<ASIGNATURA> lista = new List<ASIGNATURA>();
                if (String.IsNullOrEmpty(palabraBusqueda))
                {
                    lista = (from e in db.ASIGNATURAs
                        select e).ToList();
                    return lista;
                }
                else
                {
                    lista = (from e in db.ASIGNATURAs where (e.NOMADIGNATURA.Contains(palabraBusqueda) | e.IDASIGNATURA.Contains(palabraBusqueda)) 
                             select e).ToList();
                    return lista;
                    
                }

            }
            catch (Exception)
            {
                return new List<ASIGNATURA>();
            }
            
        }
        public static ASIGNATURA VisualizarAsignatura(string idAsignatura)
        {
            try
            {
                var db = new GestionProgramasEntities();
                var asignatura = (from e in db.ASIGNATURAs where e.IDASIGNATURA.Equals(idAsignatura)
                                          select e).First();
                return asignatura;

            }
            catch (Exception)
            {
                return null;
            }

        }

        internal static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria,string modalidad, string clasificacion, string estadoasignatura)
        {
            try
            {
                var db = new GestionProgramasEntities();

                var asg = new ASIGNATURA();
                {
                    asg.IDASIGNATURA = idAsignatura;
                    asg.IDPLANESTUDIOS = idPlantadeEstudios;
                    asg.NOMADIGNATURA = nombreAsignatura;
                    asg.CORREQUISITOSASIGNATURA = correquisitos;
                    asg.PREREQUISITOSASIGNATURA = prerequisitos;
                    asg.SEMESTREASIGNATURA = semestre;
                    asg.INTENSIDADHORARIA = intensidadhoraria;
                    asg.ESTADOASIGNATURA = estadoasignatura;
                    asg.CLASIFICACION = clasificacion;
                    asg.MODALIDAD = modalidad;
                }
                db.ASIGNATURAs.Add(asg);
                db.SaveChanges();
                return 0;

            }
            catch (Exception)
            {

                return -1;
            }
             
        }
        internal static int ModificarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            try
            {
                var db = new GestionProgramasEntities();

                var asignatura = (from asig in db.ASIGNATURAs where asig.IDASIGNATURA.Equals((idAsignatura)) select asig).First();
                {
                    asignatura.NOMADIGNATURA = nombreAsignatura;
                    asignatura.CORREQUISITOSASIGNATURA = correquisitos;
                    asignatura.PREREQUISITOSASIGNATURA = prerequisitos;
                    asignatura.SEMESTREASIGNATURA = semestre;
                    asignatura.INTENSIDADHORARIA = intensidadhoraria;
                    asignatura.ESTADOASIGNATURA = estadoasignatura;
                    asignatura.CLASIFICACION = clasificacion;
                    asignatura.MODALIDAD = modalidad;
                    db.SaveChanges();
                }
                return 0;

            }
            catch (Exception)
            {
                return -1;
            }
            
        }

        internal static int EliminarAsignatura(string idAsignatura)
        {
            try
            {
                var db = new GestionProgramasEntities();

                var asg = (from asig in db.ASIGNATURAs where asig.IDASIGNATURA.Equals((idAsignatura)) select asig).First();
                db.ASIGNATURAs.Remove(asg);
                db.SaveChanges();
                return 0;

            }
            catch (Exception)
            {
                return -1;
            }
            
        }

        internal static int CargarInformacion(string archivo)
        {
            String linea;
            StreamReader f = new StreamReader(archivo);
            try
            {
                while ((linea = f.ReadLine()) != null)
                {
                    string[] campos = linea.Split(',');
                    var db = new GestionProgramasEntities();

                    var asg = new ASIGNATURA();
                    {
                        asg.IDASIGNATURA = campos[0];
                        asg.IDPLANESTUDIOS = campos[1];
                        asg.NOMADIGNATURA = campos[2];
                        asg.CORREQUISITOSASIGNATURA = campos[3];
                        asg.PREREQUISITOSASIGNATURA = campos[4];
                        asg.SEMESTREASIGNATURA = short.Parse(campos[5]);
                        asg.INTENSIDADHORARIA = short.Parse(campos[6]);
                        asg.MODALIDAD = campos[7];
                        asg.CLASIFICACION = campos[8];
                        asg.ESTADOASIGNATURA = campos[9];
                    }
                    db.ASIGNATURAs.Add(asg);
                    db.SaveChanges();
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
