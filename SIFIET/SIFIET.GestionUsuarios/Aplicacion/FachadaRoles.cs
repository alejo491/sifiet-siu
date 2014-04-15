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
            public static void RegistrarRoles(string idRol,string nomRol,string descRol,string estadoRol)
            {
                ServicioRoles.RegistrarRol( idRol, nomRol,  descRol,  estadoRol);
            }

            public static ROL ConsultarRol(string idRol)
            {
                return ServicioRoles.ConsultarRol(idRol);
            }

            public static void ModificarRol(ROL rol)
            {
                ServicioRoles.ModificarRol(rol);
            }

            public static void EliminarRol(string idRol)
            {
                ServicioRoles.EliminarRol(idRol);
            }
        }
}
