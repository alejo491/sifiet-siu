using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.GestionUsuarios.Dominio.Servicios
{
    static class ServicioUsuarios
    {

        public static List<USUARIO> ConsultarUsuarios() {

            var db = new UsuarioEntities();

            List<USUARIO> lista = (from e in db.USUARIOs
                                   select e).ToList();
            return lista;
        }

        
        internal static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            var db = new UsuarioEntities();
            var usuario = new USUARIO()
            {
                APELLIDOSUSUARIO = apellidosUsuario,
                EMAILINSTITUCIONALUSUARIO = emailInstitucional,
                ESTADO = estado,
                IDENTIFICACIONUSUARIO = identificacionUsuario,
                IDUSUARIO = idUsuario,
                NOMBRESUSUARIO = nombresUsuario,
                PASSWORDUSUARIO = passwordUsuario
            };

            db.USUARIOs.Add(usuario);
            db.SaveChanges();
        }
    }

}
