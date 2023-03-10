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
using Moq;

namespace DevSys.Gesinv.Unit.Test
{
    [TestClass]
    public class SalidaServiceTest
    {
        private static IGenericService<Salida> _salidaService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Salida>> _genericRepository = new GenericRepositoryMock<Salida>()._genericRepository;

            _salidaService = new SalidaService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionSalida()
        {
            //Arrancar
            Salida _salida = new Salida()
            {
                SalidaId = 5,
                MotivoId = 2,
                Fecha = DateTime.Now,
                Comentario = "Nada",
                BodegaId = 3,
            };

            //Actuar
            bool resultado = await _salidaService.Create(_salida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateSalida()
        {
            //Arrancar
            Salida _salida = new Salida()
            {
                SalidaId = 5,
                MotivoId = 5,
                Fecha = DateTime.Now,
                Comentario = "Hola",
                BodegaId = 3,
            };

            //Actuar
            bool resultado = await _salidaService.Update(_salida);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetSalida()
        {
            //Arrancar
            int id = 5;

            //Actuar
            var resultado = await _salidaService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteSalida()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _salidaService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetSalidas()
        //{

        //}
    }
}
