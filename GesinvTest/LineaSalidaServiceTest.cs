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
    public class LineaSalidaServiceTest
    {
        private static IGenericService<LineaSalida> _lineaSalidaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<LineaSalida>> _genericRepository = new GenericRepositoryMock<LineaSalida>()._genericRepository;

            _lineaSalidaService = new LineaSalidaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionLineaSalida()
        {
            //Arrancar
            LineaSalida _lineaSalida = new LineaSalida()
            {
                LineaSalidaId = 6,
                SalidaId = 2,
                ProductoId = 1,
                CostoSalida = 20,
                Cantidad = 200,
            };

            //Actuar
            bool resultado = await _lineaSalidaService.Create(_lineaSalida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateLineaSalida()
        {
            //Arrancar
            LineaSalida _lineaSalida = new LineaSalida()
            {
                LineaSalidaId = 6,
                SalidaId = 2,
                ProductoId = 1,
                CostoSalida = 20,
                Cantidad = 200,
            };

            //Actuar
            bool resultado = await _lineaSalidaService.Create(_lineaSalida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetLineaSalida()
        {
            //Arrancar
            int id = 6;

            //Actuar
            var resultado = await _lineaSalidaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteLineaSalida()
        {
            //Arrancar
            int id = 6;

            //Actuar
            bool resultado = await _lineaSalidaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }


        //[TestMethod]
        //public async void valida_GetLineasDeSalida()
        //{

        //}
    }
}
