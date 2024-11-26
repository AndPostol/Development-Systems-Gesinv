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
    public class BodegaServiceTest
    {
        private static IGenericService<Bodega> _bodegaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Bodega>> _genericRepository = new GenericRepositoryMock<Bodega>()._genericRepository;

            _bodegaService = new BodegaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionBodega()
        {
            //Arrancar
            Bodega _bodega = new Bodega()
            {
                BodegaId = 40,
                Direccion = "Cumanacoto",
                EmpresaId = 2,
                ProvinciaId = 5,
                EstadoId = 6,
            };

            //Actuar
            bool resultado = await _bodegaService.Create(_bodega);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateBodega()
        {
            //Arrancar
            Bodega _bodega = new Bodega()
            {
                BodegaId = 40,
                Direccion = "Cumanacoto",
                EmpresaId = 2,
                ProvinciaId = 5,
                EstadoId = 6,
            };

            //Actuar
            bool resultado = await _bodegaService.Update(_bodega);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteBodega()
        {
            //Arrancar
            int id = 3;

            //Actuar
            bool resultado = await _bodegaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetBodega()
        {
            //Arrancar
            int id = 2;

            //Actuar
            var resultado = await _bodegaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetBodegas()
        //{

        //}

    }
}
