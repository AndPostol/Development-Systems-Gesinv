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
    public class MotivoServiceTest
    {
        private static IGenericService<Motivo> _motivoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Motivo>> _genericRepository = new GenericRepositoryMock<Motivo>()._genericRepository;

            _motivoService = new MotivoService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionMotivo()
        {
            //Arrancar
            Motivo _motivo = new Motivo()
            {
                MotivoId = 5,
                Nombre = "Pedido",
            };

            //Actuar
            bool resultado = await _motivoService.Create(_motivo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateMotivo()
        {
            //Arrancar
            Motivo _motivo = new Motivo()
            {
                MotivoId = 5,
                Nombre = "Donacion",
            };

            //Actuar
            bool resultado = await _motivoService.Update(_motivo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetMotivo()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _motivoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteMotivo()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _motivoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetMotivos()
        //{

        //}
    }
}
