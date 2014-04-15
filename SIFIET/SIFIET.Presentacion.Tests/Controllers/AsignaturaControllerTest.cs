using System;
using System.Web.Mvc;
using SIFIET.Presentacion.Controllers;
using NUnit.Framework;
using SIFIET.GestionProgramas.Datos.Modelo;
using SIFIET.Aplicacion;


namespace SIFIET.Presentacion.Tests
{
    [TestFixture]
    public class AsignaturaControllerTest
    {
        [Test]
        public void PruebaEditarAsignaturas1()
        {
            
            AsignaturaController controller = new AsignaturaController();
            var actual = controller.ModificarAsignatura("");
            Assert.IsInstanceOf<ViewResult>(actual);

        }
        [Test]
        public void PruebaInsertarAsignatura()
        {
            var idAsignatura = "sis2016";
            var actualRegistrar = FachadaSIFIET.RegistrarAsignatura(idAsignatura, "1", "ondas", "sis202", "sis203", 1, 1, "alta", "diruna", "activo");
            Assert.AreEqual(0, actualRegistrar);
            var asignatura = FachadaSIFIET.VisualizarAsignatura(idAsignatura);
            Assert.AreEqual(idAsignatura, asignatura.IDASIGNATURA);
            var actualModificar = FachadaSIFIET.ModificarAsignatura(idAsignatura, "1", "ondas2", "sis202", "sis203", 1, 1, "alta", "diruna", "activo");
            Assert.AreEqual(0, actualModificar);
            var actualEliminar = FachadaSIFIET.EliminarAsignatura((idAsignatura));
            Assert.AreEqual(0, actualEliminar);
            
        }
        [Test]
        public void PruebaEditarAsignatura()
        {
            var idAsignatura = "sis2016";
            var actualRegistrar = FachadaSIFIET.RegistrarAsignatura(idAsignatura, "1", "ondas", "sis202", "sis203", 1, 1, "alta", "diruna", "activo");
            Assert.AreEqual(0, actualRegistrar);
            var asignaturaSinModificar = FachadaSIFIET.VisualizarAsignatura(idAsignatura);
            Assert.AreEqual(idAsignatura, asignaturaSinModificar.IDASIGNATURA);
            var actualModificar = FachadaSIFIET.ModificarAsignatura(idAsignatura, "1", "ondascambio", "sis202cambio", "sis203cambio", 1, 1, "altacambio", "dirunacambio", "inactivo");
            Assert.AreEqual(0, actualModificar);
            var asignaturaModificada = FachadaSIFIET.VisualizarAsignatura(idAsignatura);
            Assert.AreNotSame(asignaturaModificada, asignaturaSinModificar);
            var actualEliminar = FachadaSIFIET.EliminarAsignatura((idAsignatura));
            Assert.AreEqual(0, actualEliminar);

        }
        [Test]
        public void PruebaEliminarAsignatura()
        {
            var idAsignatura = "sis2016";
            var actualRegistrar = FachadaSIFIET.RegistrarAsignatura(idAsignatura, "1", "ondas", "sis202", "sis203", 1, 1, "alta", "diruna", "activo");
            Assert.AreEqual(0, actualRegistrar);
            var actualEliminar = FachadaSIFIET.EliminarAsignatura((idAsignatura));
            Assert.AreEqual(0, actualEliminar);
            var asignatura = FachadaSIFIET.VisualizarAsignatura(idAsignatura);
            Assert.IsNull(asignatura);

        }

        [Test]
        public void PruebaEditarAsignaturas2()
        {
            ASIGNATURA prueba = new ASIGNATURA();
            prueba.IDASIGNATURA = "";
            prueba.IDPLANESTUDIOS = "";
            prueba.NOMADIGNATURA = "";
            prueba.CORREQUISITOSASIGNATURA = "";
            prueba.PREREQUISITOSASIGNATURA = "";
            prueba.SEMESTREASIGNATURA = 1234;
            prueba.INTENSIDADHORARIA = 1234;
            prueba.MODALIDAD = "";
            prueba.CLASIFICACION = "";
            prueba.ESTADOASIGNATURA = "";
            AsignaturaController controller = new AsignaturaController();
            var actual = controller.ModificarAsignatura(prueba);
            Assert.IsInstanceOf<RedirectToRouteResult>(actual);
            //Assert.IsInstanceOf<ViewResult>(actual);

        }
        [Test]
        public void PruebaEditarAsignaturas3()
        {
            var actual = FachadaSIFIET.ModificarAsignatura(null, "1", "", "", "", null, null, "", "", "");
            Assert.AreEqual(-1,actual);

        }
        [Test]
        public void PruebaEditarAsignaturas4()
        {
            var actual = FachadaSIFIET.ModificarAsignatura("1", null, "", "", "", null, null, "", "", "");
            Assert.AreEqual(-1, actual);
        }
        [Test]
        public void PruebaEditarAsignaturas5()//idAsignatura = sis102 exite en la bd - no existe idPlanEstudio
        {
            var actual = FachadaSIFIET.ModificarAsignatura("sis102", "IdPlanEstudio", "", "", "", 10000, null, "", "", "");
            Assert.AreEqual(-1, actual);
        }
        [Test]
        public void PruebaEditarAsignaturas6()//idAsignatura = sis2013 no existe no se puede modificar
        {
            var actual = FachadaSIFIET.ModificarAsignatura("sis2013", "1", "", "", "", 10000,10000, "", "", "");
            Assert.AreEqual(-1, actual);
        }
        
    }
}
