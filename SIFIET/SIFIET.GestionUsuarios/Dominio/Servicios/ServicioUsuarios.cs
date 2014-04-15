using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using SIFIET.GestionUsuarios.Datos.Modelo;
using System.Data;


namespace SIFIET.GestionUsuarios.Dominio.Servicios
{
    static class ServicioUsuarios
    {

        public static List<USUARIO> ConsultarUsuarios()
        {

            var db = new UsuariosEntities();

            List<USUARIO> lista = (from e in db.USUARIOs
                                   select e).ToList();
            return lista;
        }


        internal static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            var db = new UsuariosEntities();

            var usuario = new USUARIO()
            {
                IDUSUARIO = idUsuario.ToString(),
                APELLIDOSUSUARIO = apellidosUsuario,
                EMAILINSTITUCIONALUSUARIO = emailInstitucional,
                ESTADOUSUARIO = estado,
                IDENTIFICACIONUSUARIO = identificacionUsuario,
                NOMBRESUSUARIO = nombresUsuario,
                PASSWORDUSUARIO = passwordUsuario
            };

            db.USUARIOs.Add(usuario);
            db.SaveChanges();
        }

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities();
            return db.USUARIOs.Find(idUsuario);
        }

        internal static void ModificarUsuario(USUARIO usuario)
        {
            var db = new UsuariosEntities();
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void EliminarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities();

            var usuario = db.USUARIOs.Find(idUsuario);
            db.USUARIOs.Remove(usuario);
            db.SaveChanges();
        }

        internal static List<USUARIO> BuscarUsuarioPorIdentificacion(string id)
        {
            var db = new UsuariosEntities();
            List<USUARIO> lista = (from e in db.USUARIOs
                                   where SqlFunctions.StringConvert(e.IDENTIFICACIONUSUARIO).Contains(id)
                                   select e).ToList();
            return lista;
        }

        internal static List<USUARIO> BuscarUsuarioPorNombre(string nombre)
        {
            var db = new UsuariosEntities();
            List<USUARIO> lista = (from e in db.USUARIOs
                                   where e.NOMBRESUSUARIO.Contains(nombre)
                                   select e).ToList();
            return lista;
        }

        internal static List<USUARIO> BuscarUsuarioPorApellido(string apellido)
        {
            var db = new UsuariosEntities();
            List<USUARIO> lista = (from e in db.USUARIOs
                                   where e.APELLIDOSUSUARIO.Contains(apellido)
                                   select e).ToList();
            return lista;
        }

        internal static string GenerarCodigo()
        {
            var db = new UsuariosEntities();
            string codigo = (from e in db.USUARIOs
                             orderby e.IDUSUARIO descending
                             select e.IDUSUARIO).FirstOrDefault();
            if (codigo == null) codigo = "0";

            return (int.Parse(codigo) + 1).ToString();
        }

        internal static void AsignarRol(string idUsuario, string rol)
        {
            var db = new UsuariosEntities();
            ROL x = (from e in db.ROLs
                     where e.IDROL == rol
                     select e).FirstOrDefault();
            ConsultarUsuario(idUsuario).ROLs.Add(x);
            db.SaveChanges();
            
        }
    }

}
