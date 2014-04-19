using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SIFIET.Aplicacion;
using SIFIET.GestionProgramas.Datos.Modelo;
using SIFIET.Presentacion.Controllers;

namespace SIFIET.Presentacion.Tests.Controllers
{
    [TestFixture]
    public class ProgramaControllerTest
    {
        [Test]
        public void PruebaEliminarPrograma()
        {
            PROGRAMA programa = new PROGRAMA();
            programa.IDPROGRAMA = "100";
            programa.IDFACULTAD = "1"; //Debe estar en la base datos un registro Plan de estudios con ese codigo;
            programa.NOMPROGRAMA = "Ingenieria de Sistemas";
            FachadaSIFIET.RegistrarPrograma(programa);
            FachadaSIFIET.EliminarPrograma(programa);

        }
    }
}
