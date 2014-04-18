using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIFIET.Aplicacion;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.Presentacion.Controllers
{
    public class RolController:Controller
    {
        public ActionResult Index()
        {
            return View(FachadaSIFIET.ConsultarRoles());
        }
        [HttpPost]
        public ActionResult Index(FormCollection datos)
        {
            var oRoles=new List<ROL>();
            if (datos["criterio"].Equals("nombre"))
            {
                oRoles = FachadaSIFIET.BuscarRolPorNombre((datos["valorbusqueda"]));
            }
            if (datos["criterio"].Equals("estado"))
            {
                oRoles = FachadaSIFIET.BuscarRolPorEstado((datos["valorbusqueda"]));
            }
            if (!oRoles.Any())
            {
                ViewBag.Mensaje = "Ningun Rol Encontrado";
            }
            else
            {
                oRoles = FachadaSIFIET.ConsultarRoles();
            }
            return View(oRoles);

        }
        public ActionResult AgregarRol()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarRol(FormCollection datos)
        {
            bool valido = true;
            if (datos["NOMROL"].Trim().Equals(""))
            {
                ViewBag.ErrorNombreRol = "Campo Requerido";
                valido = false;
            }
            else {
                if (FachadaSIFIET.ExisteNombre(datos["NOMROL"].Trim()))
                {
                    ViewBag.ErrorNombreRol = "Nombre Ya Registrado";
                    valido = false;
                }
            }
            if (datos["DESCROL"].Trim().Equals(""))
            {
                ViewBag.ErrorDescripcionRol = "Campo Requerido";
                valido = false;
            }
            if (!ModelState.IsValid || !valido) return View();
            var permisos = CrearPermisos(datos);
            try
            {
                FachadaSIFIET.RegistrarRoles(datos["NOMROL"].Trim(),
                    datos["DESCROL"].Trim(),"Activo", permisos);
                ViewBag.Mensaje = "Rol Creado con Exito";
                TempData["Mensaje"] = "Rol Creado con Exito";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Error: " + e.Message;
            }
            return View();
        }

        public ActionResult VisualizarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        public ActionResult ModificarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarRol(FormCollection datos)
        {
            ViewBag.idUsuario = datos["IDROL"];
            int x;
            bool valido = true;
            if (datos["IDROL"].Trim().Equals(""))
            {
                ViewBag.ErrorIdRol = "Campo Requerido";
                valido = false;
            }
            else
                if (!int.TryParse(datos["IDROL"], out x))
                {
                    ViewBag.ErrorIdRol = "Solo Valores Numericos";
                    valido = false;
                }
            if (datos["NOMROL"].Trim().Equals(""))
            {
                ViewBag.ErrorNombreRol = "Campo Requerido";
                valido = false;
            }
            else
            {
                if (!datos["NOMROL"].Trim().Equals(datos["NOMROLNOW"].Trim()) && FachadaSIFIET.ExisteNombre(datos["NOMROL"].Trim()))
                {
                    ViewBag.ErrorNombreRol = "Nombre Ya Registrado";
                    valido = false;
                }
            }
            if (datos["DESCROL"].Trim().Equals(""))
            {
                ViewBag.ErrorDescripcionRol = "Campo Requerido";
                valido = false;
            }
            if (!ModelState.IsValid || !valido)
            {
                return View(FachadaSIFIET.ConsultarRol(datos["IDROL"].Trim()));
            }
            var permisos = CrearPermisos(datos);
            try
            {
                FachadaSIFIET.ModificarRol(datos["IDROL"].Trim(), datos["NOMROL"].Trim(),
                    datos["DESCROL"].Trim(), "Activo", permisos);
                ViewBag.Mensaje = "Rol Modificado con Exito";
                TempData["Mensaje"] = "Rol Modificado con Exito";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Error: " + e.Message;
            }
            return View();
        }

        public ActionResult EliminarRol(string idRol)
        {
            return View(FachadaSIFIET.ConsultarRol(idRol));
        }

        [HttpPost, ActionName("EliminarRol")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string idRol)
        {
            FachadaSIFIET.EliminarRol(idRol);
            return RedirectToAction("Index");
        }

        public static List<PERMISO> CrearPermisos(FormCollection datos)
        {
            var permisos=new List<PERMISO>();
            var permiso=new PERMISO
            {
                NOMPERMISO = "Plan de Estudios",
                GESTIONAR = datos["Plan de Estudios"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            permiso = new PERMISO
            {
                NOMPERMISO = "Usuarios", 
                GESTIONAR = datos["Usuarios"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            permiso = new PERMISO
            {
                NOMPERMISO = "Programas", 
                GESTIONAR = datos["Programas"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            permiso = new PERMISO
            {
                NOMPERMISO = "Infraestructura",
                GESTIONAR = datos["Infraestructura"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            permiso = new PERMISO
            {
                NOMPERMISO = "Asignaturas",
                GESTIONAR = datos["Asignaturas"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            permiso = new PERMISO
            {
                NOMPERMISO = "Salones", 
                GESTIONAR = datos["Salones"].Trim().Equals("Gestionar") ? 1 : 0
            };
            permisos.Add(permiso);
            return permisos;
        }
    }
}