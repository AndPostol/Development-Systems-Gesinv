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
    public class TipoServiceTest
    {
        private static IGenericService<Tipo> _tipoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Tipo>> _genericRepository = new GenericRepositoryMock<Tipo>()._genericRepository;

            _tipoService = new TipoService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionTipo()
        {
            //Arrancar
            Tipo _tipo = new Tipo()
            {
                TipoId = 5,
                Nombre = "Insumo",
            };

            //Actuar
            bool resultado = await _tipoService.Create(_tipo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateTipo()
        {
            //Arrancar
            Tipo _tipo = new Tipo()
            {
                TipoId = 5,
                Nombre = "Alimento",
            };

            //Actuar
            bool resultado = await _tipoService.Update(_tipo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetTipo()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _tipoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteTipo()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _tipoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetTipos()
        //{

        //}
    }
}
