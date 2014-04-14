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

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            return SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.ConsultarUsuario(idUsuario);
        }

        public static void ModificarUsuario(USUARIO usuario)
        {
            SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(string idUsuario)
        {
            SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.EliminarUsuario(idUsuario);
        }

        public static List<ASIGNATURA> ConsultarAsignaturas()
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarAsignaturas();
        }

        public static ASIGNATURA VisualizarAsignatura(string idAsignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.VisualizarAsignatura(idAsignatura);
        }

        public static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.RegistrarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);

        }
        public static int ModificarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short semestre, short intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ModificarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);
        }

        public static int EliminarAsignatura(string idAsignatura)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.EliminarAsignatura(idAsignatura);
        }

    }
}
