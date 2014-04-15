using System;
using NUnit.Framework;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.Aplicacion;
using System.Collections.Generic;

namespace SIFIET.Presentacion.Tests.Controllers
{
    [TestFixture]
    public class UsuarioControllerTest
    {
        [Test]
        public void TestAgregarUsuario()
        {
            USUARIO usuarioRegistrar = new USUARIO();
            usuarioRegistrar.IDUSUARIO = "123321         ";
            usuarioRegistrar.EMAILINSTITUCIONALUSUARIO = "prueba";
            usuarioRegistrar.PASSWORDUSUARIO = "prueba";
            usuarioRegistrar.IDENTIFICACIONUSUARIO = 123;
            usuarioRegistrar.NOMBRESUSUARIO = "prueba";
            usuarioRegistrar.APELLIDOSUSUARIO = "prueba";
            usuarioRegistrar.ESTADOUSUARIO = "prueba";
            string[] roles = {"1"};
            FachadaSIFIET.RegistrarUsuario(usuarioRegistrar, roles);
            USUARIO usuarioConsultar = FachadaSIFIET.ConsultarUsuario(usuarioRegistrar.IDUSUARIO);
            Assert.AreEqual(usuarioRegistrar.IDUSUARIO, usuarioConsultar.IDUSUARIO);
            FachadaSIFIET.EliminarUsuario(usuarioRegistrar.IDUSUARIO);
        }

        [Test]
        public void TestModificarUsuario()
        {
            USUARIO usuarioRegistrar = new USUARIO();
            usuarioRegistrar.IDUSUARIO = "123321         ";
            usuarioRegistrar.EMAILINSTITUCIONALUSUARIO = "prueba";
            usuarioRegistrar.PASSWORDUSUARIO = "prueba";
            usuarioRegistrar.IDENTIFICACIONUSUARIO = 123;
            usuarioRegistrar.NOMBRESUSUARIO = "prueba";
            usuarioRegistrar.APELLIDOSUSUARIO = "prueba";
            usuarioRegistrar.ESTADOUSUARIO = "prueba";
            string[] roles = { "1" };
            FachadaSIFIET.RegistrarUsuario(usuarioRegistrar, roles);            
            usuarioRegistrar.EMAILINSTITUCIONALUSUARIO = "correoPruebaUnitaria";
            FachadaSIFIET.ModificarUsuario(usuarioRegistrar, roles);            
            Assert.AreEqual(usuarioRegistrar.EMAILINSTITUCIONALUSUARIO, "correoPruebaUnitaria");
            FachadaSIFIET.EliminarUsuario(usuarioRegistrar.IDUSUARIO);
        }

        [Test]
        public void TestEliminarUsuario()
        {
            USUARIO usuarioRegistrar = new USUARIO();
            usuarioRegistrar.IDUSUARIO = "123321         ";
            usuarioRegistrar.EMAILINSTITUCIONALUSUARIO = "prueba";
            usuarioRegistrar.PASSWORDUSUARIO = "prueba";
            usuarioRegistrar.IDENTIFICACIONUSUARIO = 123;
            usuarioRegistrar.NOMBRESUSUARIO = "prueba";
            usuarioRegistrar.APELLIDOSUSUARIO = "prueba";
            usuarioRegistrar.ESTADOUSUARIO = "prueba";
            string[] roles = { "1" };
            FachadaSIFIET.RegistrarUsuario(usuarioRegistrar, roles);
            FachadaSIFIET.EliminarUsuario(usuarioRegistrar.IDUSUARIO);
            USUARIO usuarioConsultar = FachadaSIFIET.ConsultarUsuario(usuarioRegistrar.IDUSUARIO);
            Assert.IsNull(usuarioConsultar);
        }
    }
}
