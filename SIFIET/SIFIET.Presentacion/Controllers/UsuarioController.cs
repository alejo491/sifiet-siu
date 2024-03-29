﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SIFIET.Aplicacion;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            List<USUARIO> lista= FachadaSIFIET.ConsultarUsuarios();
            if (lista.Count ==0)
            {
                ViewBag.Mensaje = "No hay registros disponibles";
            }
            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(FormCollection datos)
        {
            if (datos["criterio"].Equals("nombre"))
            {
                List<USUARIO> lista = FachadaSIFIET.BuscarUsuarioPorNombre((datos["valorbusqueda"]));
                if (lista.Count == 0)
                {
                    ViewBag.Mensaje = "No se han encontrado registros con el dato indicado, por favor intentelo de nuevo";
                }
                return View(lista);
            }
            if (datos["criterio"].Equals("apellido"))
            {
                List<USUARIO> lista = FachadaSIFIET.BuscarUsuarioPorApellido(datos["valorbusqueda"]);
                if (lista.Count == 0)
                {
                    ViewBag.Mensaje = "No se han encontrado registros con el dato indicado, por favor intentelo de nuevo";
                }
                return View(lista);
            }
            if (datos["criterio"].Equals("identificacion"))
            {
                List<USUARIO> lista = FachadaSIFIET.BuscarUsuarioPorIdentificacion(int.Parse(datos["valorbusqueda"]));
                if (lista.Count == 0)
                {
                    ViewBag.Mensaje = "No se han encontrado registros con el dato indicado, por favor intentelo de nuevo";
                }
                return View(lista);
            }


            return View(FachadaSIFIET.ConsultarUsuarios());




        }

        public ActionResult AgregarUsuario()
        {
            ViewBag.idUsuario = FachadaSIFIET.GenerarCodigo();
            ViewBag.roles = FachadaSIFIET.ConsultarRoles();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(FormCollection datos)
        {
            ViewBag.idUsuario = datos["IDUSUARIO"];
            ViewBag.roles = FachadaSIFIET.ConsultarRoles();
            bool error = false;
            int x;
            if (datos["IDUSUARIO"].Equals(""))
            {
                ViewBag.ErrorCodigo = "*";
                error = true;

            }

            if (datos["roles"] == null)
            {
                ViewBag.ErrorRol = "*";
                error = true;

            }
            if (datos["NOMBRESUSUARIO"].Equals(""))
            {
                ViewBag.ErrorNombre = "*";
                error = true;
            }
            if (datos["APELLIDOSUSUARIO"].Equals(""))
            {
                ViewBag.ErrorApellido = "*";
                error = true;
            }
            if (datos["IDENTIFICACIONUSUARIO"].Equals(""))
            {
                ViewBag.ErrorIdentificacion = "*";
                error = true;
            }
            if (datos["PASSWORDUSUARIO"].Equals(""))
            {
                ViewBag.ErrorPass = "*";
                error = true;
            }
            if (datos["EMAILINSTITUCIONALUSUARIO"].Equals(""))
            {
                ViewBag.ErrorEmail = "*";
                error = true;
            }

            if (datos["IDENTIFICACIONUSUARIO"].Equals(""))
            {
                ViewBag.ErrorIdentificacion = "*";
                error = true;
            }

            if (error)
            {
                ViewBag.Mensaje = "* estos campos son obligatorios";
            }
            else if (!int.TryParse(datos["IDENTIFICACIONUSUARIO"], out x))
            {
                ViewBag.ErrorIdentificacion = "Esta campo solo recive valores numericos";
            }
            else if (FachadaSIFIET.BuscarUsuarioPorIdentificacion(int.Parse(datos["IDENTIFICACIONUSUARIO"])).Count>0)
            {
                ViewBag.ErrorIdentificacion = "Ya existe un usuario con esta identificacion";
            }
            else
            {
                try
                {
                    var usuario = new USUARIO()
                    {
                        IDUSUARIO = datos["IDUSUARIO"],
                        APELLIDOSUSUARIO = datos["APELLIDOSUSUARIO"],
                        EMAILINSTITUCIONALUSUARIO = datos["EMAILINSTITUCIONALUSUARIO"],
                        ESTADOUSUARIO = "false",
                        IDENTIFICACIONUSUARIO = int.Parse(datos["IDENTIFICACIONUSUARIO"]),
                        NOMBRESUSUARIO = datos["NOMBRESUSUARIO"],
                        PASSWORDUSUARIO = datos["PASSWORDUSUARIO"]
                    };

                    var roles = datos["roles"].Split(',');
                    


                    FachadaSIFIET.RegistrarUsuario(usuario,roles);
                    ViewBag.idUsuario = FachadaSIFIET.GenerarCodigo();
                    
                    ViewBag.Mensaje = "Registro Exitoso";
                }
                catch (Exception e)
                {

                    ViewBag.Mensaje = "Error" + e.Message;
                }

            }
            return View();
        }

        public ActionResult VisualizarUsuario(string idUsuario)
        {
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        public ActionResult ModificarUsuario(string idUsuario)
        {
            ViewBag.roles = FachadaSIFIET.ConsultarRoles();
            
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarUsuario(
            [Bind(
                Include =
                    "IDUSUARIO,EMAILINSTITUCIONALUSUARIO,PASSWORDUSUARIO,IDENTIFICACIONUSUARIO,NOMBRESUSUARIO,APELLIDOSUSUARIO,ESTADO"
                )] USUARIO usuario,FormCollection datos)
        {

            ViewBag.roles = FachadaSIFIET.ConsultarRoles();
            bool error = false;
            int x;

            if (usuario.NOMBRESUSUARIO == null)
            {
                ViewBag.ErrorNombre = "*";
                error = true;
            }
            if (usuario.APELLIDOSUSUARIO == null)
            {
                ViewBag.ErrorApellido = "*";
                error = true;
            }

            if (usuario.PASSWORDUSUARIO == null)
            {
                ViewBag.ErrorPass = "*";
                error = true;
            }
            if (usuario.EMAILINSTITUCIONALUSUARIO == null)
            {
                ViewBag.ErrorEmail = "*";
                error = true;
            }
            if (usuario.IDENTIFICACIONUSUARIO == null)
            {
                ViewBag.ErrorIdentificacion = "*";
                error = true;
            }
            if (datos["roles"] == null)
            {
                ViewBag.ErrorRol = "*";
                error = true;

            }


            if (error)
            {
                ViewBag.Mensaje = "* estos campos son obligatorios";
            }
            else 
            {
             
                try
                {
                    

                    var roles = datos["roles"].Split(',');
                    FachadaSIFIET.ModificarUsuario(usuario,roles);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {

                    ViewBag.Mensaje = "Error" + e.Message;
                    return View();
                }
            }
            return View();

        }

        public ActionResult EliminarUsuario(string idUsuario)
        {
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        [HttpPost, ActionName("EliminarUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string idUsuario)
        {
            FachadaSIFIET.EliminarUsuario(idUsuario);
            return RedirectToAction("Index");
        }

    }
}
