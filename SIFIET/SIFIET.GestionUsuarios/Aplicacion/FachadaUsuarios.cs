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




       public static void RegistrarUsuario(USUARIO usuario,string[] roles)
       {
           ServicioUsuarios.RegistrarUsuario(usuario,roles);
       }

       public static USUARIO ConsultarUsuario(string idUsuario)
       {
           return ServicioUsuarios.ConsultarUsuario(idUsuario);
       }

       public static void ModificarUsuario(USUARIO usuario, string[] roles)
       {
           ServicioUsuarios.ModificarUsuario(usuario,roles);
       }

       public static void EliminarUsuario(string idUsuario)
       {
           ServicioUsuarios.EliminarUsuario(idUsuario);
       }
       public static List<USUARIO> BuscarUsuarioPorNombre(string nombre)
       {
           return ServicioUsuarios.BuscarUsuarioPorNombre(nombre);
       }

       public static List<USUARIO> BuscarUsuarioPorApellido(string apellido)
       {
           return ServicioUsuarios.BuscarUsuarioPorApellido(apellido);
       }

       public static List<USUARIO> BuscarUsuarioPorIdentificacion(int id)
       {
           return ServicioUsuarios.BuscarUsuarioPorIdentificacion(id);
       }

       public static string GenerarCodigo()
       {
           return ServicioUsuarios.GenerarCodigo();
       }

       public static void AsignarRol(string idUsuario, string rol)
       {
           ServicioUsuarios.AsignarRol(idUsuario,rol);
       }

       
    }
}
