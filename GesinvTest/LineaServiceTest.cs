using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.Unit.Test.MockRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevSys.Gesinv.Unit.Test
{
    [TestClass]
    public class LineaServiceTest
    {
        private static IGenericService<Linea> _lineaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Linea>> _genericRepository = new GenericRepositoryMock<Linea>()._genericRepository;

            _lineaService = new LineaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionLinea()
        {
            //Arrancar
            Linea _linea = new Linea()
            {
                LineaId = 5,
                Nombre = "Blanca",
            };

            //Actuar
            bool resultado = await _lineaService.Create(_linea);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateLinea()
        {
            //Arrancar
            Linea _linea = new Linea()
            {
                LineaId = 5,
                Nombre = "Linea 2",
            };

            //Actuar
            bool resultado = await _lineaService.Update(_linea);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetLinea()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _lineaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteLinea()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _lineaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetLineas()
        //{

        //}
    }
}
