using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionProgramas.Datos.Modelo;

namespace SIFIET.GestionProgramas.Dominio.Servicios
{
    static class ServicioAsignaturas
    {
        public static List<ASIGNATURA> ConsultarAsignaturas()
        {
            try
            {
                var db = new GestionProgramasEntities();
                List<ASIGNATURA> lista = (from e in db.ASIGNATURAs
                                          select e).ToList();
                return lista;

            }
            catch (Exception)
            {
                return null;
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

        internal static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria,string modalidad, string clasificacion, string estadoasignatura)
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
        internal static int ModificarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            try
            {
                var db = new GestionProgramasEntities();

                var asg = (from asig in db.ASIGNATURAs where asig.IDASIGNATURA.Equals((idAsignatura)) select asig).First();

                asg.IDPLANESTUDIOS = idPlantadeEstudios;
                asg.NOMADIGNATURA = nombreAsignatura;
                asg.CORREQUISITOSASIGNATURA = correquisitos;
                asg.PREREQUISITOSASIGNATURA = prerequisitos;
                asg.SEMESTREASIGNATURA = semestre;
                asg.INTENSIDADHORARIA = intensidadhoraria;
                asg.ESTADOASIGNATURA = estadoasignatura;
                asg.CLASIFICACION = clasificacion;
                asg.MODALIDAD = modalidad;
                db.SaveChanges();
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


    }
}
