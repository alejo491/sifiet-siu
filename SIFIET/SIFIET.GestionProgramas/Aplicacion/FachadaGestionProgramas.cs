using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionProgramas.Datos.Modelo;
using SIFIET.GestionProgramas.Dominio.Servicios;

namespace SIFIET.GestionProgramas.Aplicacion
{
    public static class FachadaGestionProgramas
    {
        public static List<ASIGNATURA> ConsultarAsignaturas()
        {
            return ServicioAsignaturas.ConsultarAsignaturas();
        }

        public static ASIGNATURA ConsultarAsignatura(string idAsignatura)
        {
            return ServicioAsignaturas.ConsultarAsignatura(idAsignatura);
        }
        public static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria,string modalidad, string clasificacion, string estadoasignatura)
        {
            return ServicioAsignaturas.RegistrarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);

        }
        public static int ActualizarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return ServicioAsignaturas.ActualizarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);
        }

        public static int EliminarAsignatura(string idAsignatura)
        {
            return ServicioAsignaturas.EliminarAsignatura(idAsignatura);
        }
    }
}
