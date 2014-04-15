﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(FachadaSIFIET.ConsultarUsuarios());
        }

        [HttpPost]
        public ActionResult Index(FormCollection datos)
        {
            if (datos["criterio"].Equals("nombre"))
            {
                return View(FachadaSIFIET.BuscarUsuarioPorNombre((datos["valorbusqueda"])));
            }
            if (datos["criterio"].Equals("apellido"))
            {
                return View(FachadaSIFIET.BuscarUsuarioPorApellido(datos["valorbusqueda"]));
            }
            if (datos["criterio"].Equals("identificacion"))
            {
                return View(FachadaSIFIET.BuscarUsuarioPorIdentificacion(datos["valorbusqueda"]));
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
            else
            {
                try
                {


                    FachadaSIFIET.RegistrarUsuario(datos["IDUSUARIO"], datos["EMAILINSTITUCIONALUSUARIO"],
                        datos["PASSWORDUSUARIO"], int.Parse(datos["IDENTIFICACIONUSUARIO"]), datos["NOMBRESUSUARIO"],
                        datos["APELLIDOSUSUARIO"], "false");
                   var roles=datos["roles"].ToList();
                    foreach (var rol in  roles)
                    {
                        FachadaSIFIET.AsignarRol(datos["IDUSUARIO"],rol.ToString());
                    }
                    
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
            return View(FachadaSIFIET.ConsultarUsuario(idUsuario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarUsuario(
            [Bind(
                Include =
                    "IDUSUARIO,EMAILINSTITUCIONALUSUARIO,PASSWORDUSUARIO,IDENTIFICACIONUSUARIO,NOMBRESUSUARIO,APELLIDOSUSUARIO,ESTADO"
                )] USUARIO usuario)
        {

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


            if (error)
            {
                ViewBag.Mensaje = "* estos campos son obligatorios";
            }
            else if (!int.TryParse(usuario.IDENTIFICACIONUSUARIO.ToString(), out x))
            {
                ViewBag.ErrorIdentificacion = "Esta campo solo recive valores numericos";
            }
            else
            {
                try
                {
                    FachadaSIFIET.ModificarUsuario(usuario);
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
