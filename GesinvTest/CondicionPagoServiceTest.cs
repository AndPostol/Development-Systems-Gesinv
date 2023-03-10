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
    public class CondicionPagoServiceTest
    {
        private static IGenericService<CondicionPago> _condicionPagoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<CondicionPago>> _genericRepository = new GenericRepositoryMock<CondicionPago>()._genericRepository;

            _condicionPagoService = new CondicionPagoService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionCondicionPago()
        {
            //Arrancar
            CondicionPago _condicionPago = new CondicionPago()
            {
                CondicionPagoId = 20,
                Nombre = "Contado",
            };

            //Actuar
            bool resultado = await _condicionPagoService.Create(_condicionPago);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateCondicionPago()
        {
            //Arrancar
            CondicionPago _condicionPago = new CondicionPago()
            {
                CondicionPagoId = 20,
                Nombre = "Contado",
            };

            //Actuar
            bool resultado = await _condicionPagoService.Update(_condicionPago);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteCondicionPago()
        {
            //Arrancar
            int id = 20;

            //Actuar
            bool resultado = await _condicionPagoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetCondicionPago()
        {
            //Arrancar
            int id = 20;

            //Actuar
            var resultado = await _condicionPagoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetCondicionesPago()
        //{

        //}
    }
}
