using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.GestionUsuarios.Dominio.Servicios;

namespace SIFIET.GestionUsuarios.Aplicacion
{
    public static class FachadaRoles
    {
            public static List<ROL> ConsultarRoles()
            {
                return ServicioRoles.Consultar();
            }
            public static void RegistrarRoles(string idRol,string nomRol,string descRol,string estadoRol,List<PERMISO> permisos )
            {
                ServicioRoles.RegistrarRol( idRol, nomRol,  descRol,  estadoRol,permisos);
            }

            public static ROL ConsultarRol(string idRol)
            {
                return ServicioRoles.ConsultarRol(idRol);
            }

            public static void ModificarRol(string idRol, string nomRol, string descRol, string estadoRol, List<PERMISO> permisos)
            {
                ServicioRoles.ModificarRol(idRol, nomRol, descRol, estadoRol, permisos);
            }

            public static void EliminarRol(string idRol)
            {
                ServicioRoles.EliminarRol(idRol);
            }

        public static List<ROL> BuscarRolPorNombre(string nombre)
        {
            return ServicioRoles.BuscarRolPorNombre(nombre);
        }

        public static List<ROL> BuscarRolPorEstado(string id)
        {
            return ServicioRoles.BuscarRolPorEstado(id);
        }
    }
}
