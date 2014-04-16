using System.Collections.Generic;
using System.Data;
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
        public static void RegistrarUsuario(USUARIO usuario, string[] roles)
        {
            FachadaUsuarios.RegistrarUsuario(usuario,roles);
        }

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            return FachadaUsuarios.ConsultarUsuario(idUsuario);
        }

        public static void ModificarUsuario(USUARIO usuario, string[] roles)
        {
            FachadaUsuarios.ModificarUsuario(usuario,roles);
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
        public static void RegistrarRoles(string idRol,string nomRol,string descRol,string estadoRol,List<PERMISO> permisos )
        {
            FachadaRoles.RegistrarRoles(idRol,nomRol,descRol,estadoRol,permisos);
        }

        public static ROL ConsultarRol(string idRol)
        {
            return FachadaRoles.ConsultarRol(idRol);
        }

        public static void ModificarRol(string idRol, string nomRol, string descRol, string estadoRol, List<PERMISO> permisos)
        {
            FachadaRoles.ModificarRol(idRol,nomRol,descRol,estadoRol,permisos);
        }

        public static void EliminarRol(string idRol)
        {
            FachadaRoles.EliminarRol(idRol);
        }
        public static List<ROL> BuscarRolPorNombre(string nombre)
        {
            return FachadaRoles.BuscarRolPorNombre(nombre);
        }

        public static List<ROL> BuscarRolPorEstado(string id)
        {
            return FachadaRoles.BuscarRolPorEstado(id);
        }

        public static List<USUARIO> BuscarUsuarioPorNombre(string nombre)
        {
            return FachadaUsuarios.BuscarUsuarioPorNombre(nombre);
        }

        public static List<USUARIO> BuscarUsuarioPorApellido(string apellido)
        {
            return FachadaUsuarios.BuscarUsuarioPorApellido(apellido);
        }

        public static List<USUARIO> BuscarUsuarioPorIdentificacion(string id)
        {
            return SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.BuscarUsuarioPorIdentificacion(id);
        }

        public static string GenerarCodigo()
        {
            return SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.GenerarCodigo();
        }

        public static int CargarInformacion(string archivo)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.CargarInformacion(archivo);
        }

        // Metodos Gestionar Programa
        public static List<PROGRAMA> ConsultarProgramas()
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarProgramas();
        }

        public static List<PROGRAMA> ConsultarProgramaPorNombre(string busqueda)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarProgramaPorNombre(busqueda);
        }

        public static void RegistrarPrograma(PROGRAMA programa)
        {
            SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.RegistrarPrograma(programa);
        }

        public static PROGRAMA ConsultarPrograma(string id)
        {
            return SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.ConsultarPrograma(id);
        }

        public static void EditarPrograma(PROGRAMA programa)
        {
            SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.EditarPrograma(programa);
        }

        public static void EliminarPrograma(PROGRAMA programa)
        {
            SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.EliminarPrograma(programa);
        }

        public static void CargarDatos(DataSet datosExcel)
        {
            SIFIET.GestionProgramas.Aplicacion.FachadaGestionProgramas.CargarDatos(datosExcel);
        }
        // Fin metodos gestionar programa

    }
}
