using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.GestionUsuarios.Dominio.Servicios
{
    static class ServicioRoles
    {

        public static List<ROL> Consultar()
        {
            try
            {
                var db = new UsuariosEntities();

                List<ROL> lista = (from e in db.ROLs
                    select e).ToList();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }


        internal static void RegistrarRol(string nomRol, string descRol,string estadoRol,List<PERMISO> permisos )
        {
            
                if (nomRol != null && descRol != null && estadoRol != null)
                {
                    var db = new UsuariosEntities();
                    var id_rol = 0;
                    string codigo_rol = (from e in db.ROLs
                                     orderby e.IDROL descending
                                     select e.IDROL).FirstOrDefault();
                    id_rol = codigo_rol == null ? 0 : int.Parse(codigo_rol) + 1;
                    var rol = new ROL()
                    {
                        IDROL = id_rol.ToString().Trim(),
                        NOMROL = nomRol.Trim(),
                        DESCROL = descRol.Trim(),
                        ESTADOROL = estadoRol.Trim(),
                    };
                    int id = 0;
                    string codigo = (from e in db.PERMISOS
                        orderby e.IDPERMISO descending
                        select e.IDPERMISO).FirstOrDefault();
                    id = codigo == null ? 0 : int.Parse(codigo);
                    foreach (var permiso in permisos)
                    {
                        id++;
                        permiso.IDPERMISO = id.ToString().Trim();
                        permiso.ROLs.Add(rol);
                        rol.PERMISOS.Add(permiso);
                        db.PERMISOS.Add(permiso);
                    }
                    db.ROLs.Add(rol);
                    db.SaveChanges();
                }
                else
                {
                    Exception e = null;
                    throw e;
                }
        }

        public static ROL ConsultarRol(string idRol)
        {
            var db = new UsuariosEntities();
            return db.ROLs.Find(idRol);
        }

        internal static void ModificarRol(string idRol, string nomRol, string descRol, string estadoRol, List<PERMISO> permisos)
        {

            if (idRol != null && nomRol != null && descRol != null && estadoRol != null)
            {
                var db = new UsuariosEntities();
                var rolActual = db.ROLs.Find(idRol);
                var permisosActuales = rolActual.PERMISOS;
                while (permisosActuales.Count > 0)
                {
                    var permiso = permisosActuales.ElementAt(0);
                    db.PERMISOS.Remove(permiso);
                    permisosActuales.Remove(permiso);
                }
                var rol = new ROL()
                {
                    IDROL = idRol.Trim(),
                    NOMROL = nomRol.Trim(),
                    DESCROL = descRol.Trim(),
                    ESTADOROL = estadoRol,
                };
                var id = 0;
                string codigo = (from e in db.PERMISOS
                    orderby e.IDPERMISO descending
                    select e.IDPERMISO).FirstOrDefault();
                id = codigo == null ? 0 : int.Parse(codigo);
                foreach (var permiso in permisos)
                {
                    id++;
                    permiso.IDPERMISO = id.ToString(CultureInfo.InvariantCulture);
                    permiso.ROLs.Add(rol);
                    rol.PERMISOS.Add(permiso);
                    db.PERMISOS.Add(permiso);
                }
                db.ROLs.Remove(rolActual);
                db.ROLs.Add(rol);
                db.SaveChanges();
            }else
                {
                    Exception e = null;
                    throw e;
                }
        }

        public static void EliminarRol(string idRol)
        {
            var db = new UsuariosEntities();

            var rol = db.ROLs.Find(idRol.Trim());
            rol.ESTADOROL = "Inactivo";
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static List<ROL> BuscarRolPorNombre(string nombre)
        {
            var db = new UsuariosEntities();
            List<ROL> lista = (from e in db.ROLs
                                   where e.NOMROL.Contains(nombre)
                                   select e).ToList();
            return lista;
        }

        public static List<ROL> BuscarRolPorEstado(string id)
        {
            var db = new UsuariosEntities();
            List<ROL> lista = (from e in db.ROLs
                                   where e.ESTADOROL.Contains(id)
                                   select e).ToList();
            return lista;
        }
        public static bool ExisteNombre(string nombre)
        {
            var db = new UsuariosEntities();
            var lista = (from e in db.ROLs
                               where e.NOMROL.Trim()== nombre.Trim()
                               select e).ToList();
            return lista.Count > 0;
        }
    }
}
