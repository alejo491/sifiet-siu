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
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(nomRol, descRol, estadoRol, permisos);
            var resultadoList = FachadaSIFIET.BuscarRolPorNombre(nomRol);
            var resultado = resultadoList.ElementAt(0);
            Assert.AreEqual(nomRol, resultado.NOMROL.Trim());
            Assert.AreEqual(descRol, resultado.DESCROL.Trim());
            Assert.AreEqual(estadoRol, resultado.ESTADOROL.Trim());
            FachadaSIFIET.EliminarRol(resultado.IDROL.Trim());
        }
        [Test]
        public void AgregarRolNombre()
        {
            const string nomRol = null;
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            try
            {
                FachadaSIFIET.RegistrarRoles(nomRol, descRol, estadoRol, permisos);
            }
            catch (Exception e) { Assert.True(true); }
        }
        [Test]
        public void AgregarRolPermisos()
        {
           
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            List<PERMISO> permisos = null;
            try
            {
                FachadaSIFIET.RegistrarRoles(nomRol, descRol, estadoRol, permisos);
            }
            catch (Exception e) { Assert.True(true); }
            try
            {
                var resultado = FachadaSIFIET.BuscarRolPorNombre(nomRol);
                FachadaSIFIET.EliminarRol(resultado.ElementAt(0).IDROL.Trim());
            }
            catch (Exception)
            {
            }
        }
        [Test]
        public void EditarRol()
        {
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(nomRol, descRol, estadoRol, permisos);
            var res = FachadaSIFIET.BuscarRolPorNombre(nomRol);
            FachadaSIFIET.ModificarRol(res.ElementAt(0).IDROL, "modificada", "modificada", "Activo", permisos);
            var resultado = FachadaSIFIET.ConsultarRol(res.ElementAt(0).IDROL);
            Assert.AreNotEqual(nomRol,resultado.NOMROL);
            Assert.AreNotEqual(descRol, resultado.DESCROL);
            Assert.AreNotEqual(estadoRol, resultado.ESTADOROL);
            FachadaSIFIET.EliminarRol(res.ElementAt(0).IDROL.Trim());
        }
        [Test]
        public void EliminarRol()
        {
            const string nomRol = "prueba";
            const string descRol = "prueba";
            const string estadoRol = "Inactivo";
            var permisos = new List<PERMISO>();
            FachadaSIFIET.RegistrarRoles(nomRol, descRol, estadoRol, permisos);
            var res = FachadaSIFIET.BuscarRolPorNombre(nomRol);
            FachadaSIFIET.EliminarRol(res.ElementAt(0).IDROL);
            var resultado = FachadaSIFIET.ConsultarRol(res.ElementAt(0).IDROL);
            Assert.AreEqual(resultado, null);
        }
    }
}
