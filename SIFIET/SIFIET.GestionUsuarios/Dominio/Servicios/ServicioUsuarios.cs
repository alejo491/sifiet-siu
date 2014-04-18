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


        internal static void RegistrarUsuario(USUARIO usuario, string[] roles)
        {
            var db = new UsuariosEntities();



            db.USUARIOs.Add(usuario);
            db.SaveChanges();



            foreach (var rol in roles)
            {
                usuario.ROLs.Add(db.ROLs.Find(rol));
            }
            db.SaveChanges();
        }

        public static USUARIO ConsultarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities();
            return db.USUARIOs.Find(idUsuario);
        }

        internal static void ModificarUsuario(USUARIO usuario, string[] roles)
        {
            var db = new UsuariosEntities();
            usuario.ROLs.Clear();
            foreach (var rol in roles)
            {

                usuario.ROLs.Add(db.ROLs.Find(rol));
            }
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();




            db.SaveChanges();
        }

        public static void EliminarUsuario(string idUsuario)
        {
            var db = new UsuariosEntities();            
            var usuario = db.USUARIOs.Find(idUsuario);
            usuario.ROLs.Clear();
            db.USUARIOs.Remove(usuario);
            db.SaveChanges();
        }

        internal static List<USUARIO> BuscarUsuarioPorIdentificacion(int id)
        {
            var db = new UsuariosEntities();
            List<USUARIO> lista = (from e in db.USUARIOs
                                   where e.IDENTIFICACIONUSUARIO == id
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
            var usuario = (from e in db.USUARIOs
                where e.IDUSUARIO == idUsuario
                select e).FirstOrDefault();

            ROL x = (from e in db.ROLs
                where e.IDROL == rol
                select e).FirstOrDefault();

            usuario.ROLs.Add(x);
            db.SaveChanges();

        }
    }

}