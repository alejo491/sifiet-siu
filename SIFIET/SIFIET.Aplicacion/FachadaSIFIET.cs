using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.GestionProgramas.Datos.Modelo;







namespace SIFIET.Aplicacion
{
    public static class  FachadaSIFIET
    {

        public static List<USUARIO> ConsultarUsuarios(){
            
            return SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.ConsultarUsuarios();
            }

        

        public static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.RegistrarUsuario(idUsuario, emailInstitucional, passwordUsuario, identificacionUsuario, nombresUsuario, apellidosUsuario, estado);
        }

        public static List<ASIGNATURA> ConsultarAsignaturas()
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarAsignaturas();
        }

        public static ASIGNATURA ConsultarAsignatura(string idAsignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarAsignatura(idAsignatura);
        }

        public static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.RegistrarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);

        }
        public static int ActualizarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ActualizarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);
        }

        public static int EliminarAsignatura(string idAsignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.EliminarAsignatura(idAsignatura);
        }

    }
}
