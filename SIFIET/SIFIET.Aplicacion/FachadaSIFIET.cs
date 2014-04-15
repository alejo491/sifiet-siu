using System.Collections.Generic;
using SIFIET.GestionProgramas.Aplicacion;
using SIFIET.GestionUsuarios.Aplicacion;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.GestionProgramas.Datos.Modelo;

namespace SIFIET.Aplicacion
{
    public static class  FachadaSIFIET
    {

        public static List<USUARIO> ConsultarUsuarios(){
            
            return FachadaUsuarios.ConsultarUsuarios();
            }
        public static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            FachadaUsuarios.RegistrarUsuario(idUsuario, emailInstitucional, passwordUsuario, identificacionUsuario, nombresUsuario, apellidosUsuario, estado);
        }

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            return FachadaUsuarios.ConsultarUsuario(idUsuario);
        }

        public static void ModificarUsuario(USUARIO usuario)
        {
            FachadaUsuarios.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(string idUsuario)
        {
            FachadaUsuarios.EliminarUsuario(idUsuario);
        }

        public static List<ASIGNATURA> ConsultarAsignaturas(string palabraBusqueda)
        {
            return FachadaGestionProgramas.ConsultarAsignaturas(palabraBusqueda);
        }

        public static ASIGNATURA VisualizarAsignatura(string idAsignatura)
        {
            return FachadaGestionProgramas.VisualizarAsignatura(idAsignatura);
        }

        public static int RegistrarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return FachadaGestionProgramas.RegistrarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);

        }
        public static int ModificarAsignatura(string idAsignatura, string idPlantadeEstudios, string nombreAsignatura, string correquisitos, string prerequisitos, short? semestre, decimal? intensidadhoraria, string modalidad, string clasificacion, string estadoasignatura)
        {
            return FachadaGestionProgramas.ModificarAsignatura(idAsignatura, idPlantadeEstudios, nombreAsignatura, correquisitos,
                prerequisitos, semestre, intensidadhoraria, modalidad, clasificacion, estadoasignatura);
        }

        public static int EliminarAsignatura(string idAsignatura)
        {
            return FachadaGestionProgramas.EliminarAsignatura(idAsignatura);
        }

        public static List<ROL> ConsultarRoles()
        {

            return FachadaRoles.ConsultarRoles();
        }
        public static void RegistrarRoles(string idRol,string nomRol,string descRol,string estadoRol)
        {
            FachadaRoles.RegistrarRoles(idRol,nomRol,descRol,estadoRol);
        }

        public static ROL ConsultarRol(string idRol)
        {
            return FachadaRoles.ConsultarRol(idRol);
        }

        public static void ModificarRol(ROL rol)
        {
            FachadaRoles.ModificarRol(rol);
        }

        public static void EliminarRol(string idRol)
        {
            FachadaRoles.EliminarRol(idRol);
        }
    }
}
