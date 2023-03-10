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
    public class MedidaServiceTest
    {
        private static IGenericService<Medida> _medidaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Medida>> _genericRepository = new GenericRepositoryMock<Medida>()._genericRepository;

            _medidaService = new MedidaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionMedida()
        {
            //Arrancar
            Medida _medida = new Medida()
            {
                MedidaId = 5,
                Dimension = "Centimetro",
            };

            //Actuar
            bool resultado = await _medidaService.Create(_medida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateMedida()
        {
            //Arrancar
            Medida _medida = new Medida()
            {
                MedidaId = 5,
                Dimension = "mililitro",
            };

            //Actuar
            bool resultado = await _medidaService.Update(_medida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetMedida()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _medidaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteMarca()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _medidaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetMedidas()
        //{

        //}
    }
}
