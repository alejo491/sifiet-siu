using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using SIFIET.Aplicacion;
using SIFIET.GestionProgramas.Datos.Modelo;
using SIFIET.GestionUsuarios.Datos.Modelo;
using SIFIET.Presentacion.Controllers;

namespace SIFIET.Presentacion.Tests.Controllers
{
    [TestFixture]
    public class RolControllerTest
    {
        [Test]
        public void AgregarRolOk()
        {
            const string idRol = "-1";
            try
            {
                FachadaSIFIET.EliminarRol(idRol);
            }
            catch (Exception) { }
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(idRol, nomRol, descRol, estadoRol, permisos);
            var resultado = FachadaSIFIET.ConsultarRol(idRol);
            Assert.AreEqual(nomRol, resultado.NOMROL.Trim());
            Assert.AreEqual(descRol, resultado.DESCROL.Trim());
            Assert.AreEqual(estadoRol, resultado.ESTADOROL.Trim());
            FachadaSIFIET.EliminarRol(idRol);
        }
        [Test]
        public void AgregarRolId()
        {
            const string idRol = null;
            try
            {
                FachadaSIFIET.EliminarRol(idRol);
            }
            catch (Exception) {}
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            try
            {
                FachadaSIFIET.RegistrarRoles(idRol, nomRol, descRol, estadoRol, permisos);
            }
            catch (Exception e) { Assert.True(true); }
        }
        [Test]
        public void AgregarRolPermisos()
        {
            const string idRol = "-1";
            try
            {
                FachadaSIFIET.EliminarRol(idRol);
            }
            catch (Exception) { }
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            List<PERMISO> permisos = null;
            try
            {
                FachadaSIFIET.RegistrarRoles(idRol, nomRol, descRol, estadoRol, permisos);
            }
            catch (Exception e) { Assert.True(true); }
            var resultado = FachadaSIFIET.ConsultarRol(idRol);
            Assert.AreEqual(resultado,null);
        }
        [Test]
        public void EditarRol()
        {
            const string idRol = "-1";
            try
            {
                FachadaSIFIET.EliminarRol(idRol);
            }
            catch (Exception) { }
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(idRol, nomRol, descRol, estadoRol, permisos);
            FachadaSIFIET.ModificarRol(idRol,"prueba2","prueba2","Activo",permisos);
            var resultado = FachadaSIFIET.ConsultarRol(idRol);
            Assert.AreNotEqual(nomRol,resultado.NOMROL);
            Assert.AreNotEqual(descRol, resultado.DESCROL);
            Assert.AreNotEqual(estadoRol, resultado.ESTADOROL);
        }
        [Test]
        public void EliminarRol()
        {
            const string idRol = "-1";
            try
            {
                FachadaSIFIET.EliminarRol(idRol);
            }
            catch (Exception) { }
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(idRol, nomRol, descRol, estadoRol, permisos);
            FachadaSIFIET.EliminarRol(idRol);
            var resultado = FachadaSIFIET.ConsultarRol(idRol);
            Assert.AreEqual(resultado, null);
        }
    }
}
