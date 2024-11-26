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
    public class ExistenciaServiceTest
    {
        private static IExistenciaService _existenciaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Existencia>> _genericRepository = new GenericRepositoryMock<Existencia>()._genericRepository;

            _existenciaService = new ExistenciaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionExistencia()
        {
            //Arrancar
            Existencia _existencia = new Existencia()
            {
                ExistenciaId = 10,
                BodegaId = 8,
                ProductoId = 6,
                Stock = 100,
            };

            //Actuar
            bool resultado = await _existenciaService.Create(_existencia);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateExistencia()
        {
            //Arrancar
            Existencia _existencia = new Existencia()
            {
                ExistenciaId = 10,
                BodegaId = 8,
                ProductoId = 6,
                Stock = 50,
            };

            //Actuar
            bool resultado = await _existenciaService.Update(_existencia);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteExistencia()
        {
            //Arrancar
            int id = 8;

            //Actuar
            bool resultado = await _existenciaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetExistencia()
        {
            //Arrancar
            int id = 8;

            //Actuar
            var resultado = await _existenciaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetExistencias()
        //{

        //}
    }
}
