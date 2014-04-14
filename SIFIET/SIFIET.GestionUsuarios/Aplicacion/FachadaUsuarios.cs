using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.GestionUsuarios.Dominio.Servicios;

namespace SIFIET.GestionUsuarios.Aplicacion
{
    public static class FachadaUsuarios
    {
       

       public static List<USUARIO> ConsultarUsuarios()
       {
           return ServicioUsuarios.ConsultarUsuarios();
       }



       
       public static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
       {
           ServicioUsuarios.RegistrarUsuario(idUsuario, emailInstitucional, passwordUsuario, identificacionUsuario, nombresUsuario, apellidosUsuario,estado);
       }

       public static USUARIO ConsultarUsuario(string idUsuario)
       {
           return ServicioUsuarios.ConsultarUsuario(idUsuario);
       }

       public static void ModificarUsuario(USUARIO usuario)
       {
           ServicioUsuarios.ModificarUsuario(usuario);
       }

       public static void EliminarUsuario(string idUsuario)
       {
           ServicioUsuarios.EliminarUsuario(idUsuario);
       }
    }
}
