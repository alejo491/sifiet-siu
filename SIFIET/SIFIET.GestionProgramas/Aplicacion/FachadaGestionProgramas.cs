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
        public static List<ASIGNATURA> ConsultarAsignaturas(string palabraBusqueda)
        {
            return ServicioAsignaturas.ConsultarAsignaturas(palabraBusqueda);
        }

        public static ASIGNATURA VisualizarAsignatura(string idAsignatura)
        {
            return ServicioAsignaturas.VisualizarAsignatura(idAsignatura);
        }
        public static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria,string modalidad, string clasificacion, string estadoasignatura)
        {
            return ServicioAsignaturas.RegistrarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);

        }
        public static int ModificarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return ServicioAsignaturas.ModificarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);
        }

        public static int EliminarAsignatura(string idAsignatura)
        {
            return ServicioAsignaturas.EliminarAsignatura(idAsignatura);
        }
    }
}
