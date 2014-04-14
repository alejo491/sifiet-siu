using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;
using System.Data;

namespace SIFIET.GestionUsuarios.Dominio.Servicios
{
    static class ServicioUsuarios
    {

        public static List<USUARIO> ConsultarUsuarios() {

            var db = new UsuariosEntities2();

            List<USUARIO> lista = (from e in db.USUARIOs
                                   select e).ToList();
            return lista;
        }

        
        internal static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            var db = new UsuariosEntities2();
            var usuario = new USUARIO()
            {
                APELLIDOSUSUARIO = apellidosUsuario,
                EMAILINSTITUCIONALUSUARIO = emailInstitucional,
                ESTADOUSUARIO = estado,
                IDENTIFICACIONUSUARIO = identificacionUsuario,
                IDUSUARIO = idUsuario,
                NOMBRESUSUARIO = nombresUsuario,
                PASSWORDUSUARIO = passwordUsuario
            };

            db.USUARIOs.Add(usuario);
            db.SaveChanges();
        }

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities2();
            return db.USUARIOs.Find(idUsuario);
        }

        internal static void ModificarUsuario(USUARIO usuario)
        {
            var db = new UsuariosEntities2();            
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void EliminarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities2();

            var usuario = db.USUARIOs.Find(idUsuario);
            db.USUARIOs.Remove(usuario);
            db.SaveChanges();
        }
    }

}
