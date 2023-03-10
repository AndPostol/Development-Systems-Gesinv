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
    public class MarcaServiceTest
    {
        private static IGenericService<Marca> _marcaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Marca>> _genericRepository = new GenericRepositoryMock<Marca>()._genericRepository;

            _marcaService = new MarcaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionMarca()
        {
            //Arrancar
            Marca _marca = new Marca()
            {
                MarcaId = 5,
                Nombre = "Langostina",
            };

            //Actuar
            bool resultado = await _marcaService.Create(_marca);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateMarca()
        {
            //Arrancar
            Marca _marca = new Marca()
            {
                MarcaId = 5,
                Nombre = "Ecko",
            };

            //Actuar
            bool resultado = await _marcaService.Update(_marca);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetMarca()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _marcaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteMarca()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _marcaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetMarcas()
        //{

        //}
    }
}
