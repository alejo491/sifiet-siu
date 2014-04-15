using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.GestionUsuarios.Dominio.Servicios
{
    static class ServicioRoles
    {

        public static List<ROL> Consultar()
        {

            var db = new UsuariosEntities();

            List<ROL> lista = (from e in db.ROLs
                                   select e).ToList();
            return lista;
        }


        internal static void RegistrarRol(string idRol,string nomRol, string descRol,string estadoRol)
        {
            var db = new UsuariosEntities();
            var rol = new ROL()
            {
                IDROL = idRol,
                NOMROL = nomRol,
                DESCROL = descRol,
            };

            db.ROLs.Add(rol);
            db.SaveChanges();
        }

        public static ROL ConsultarRol(string idRol)
        {
            var db = new UsuariosEntities();
            return db.ROLs.Find(idRol);
        }

        internal static void ModificarRol(ROL rol)
        {
            var db = new UsuariosEntities();
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void EliminarRol(string idRol)
        {
            var db = new UsuariosEntities();

            var rol = db.ROLs.Find(idRol);
            db.ROLs.Remove(rol);
            db.SaveChanges();
        }
    }
}
