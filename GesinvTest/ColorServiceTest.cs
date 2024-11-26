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
    public class ColorServiceTest
    {
        private static IGenericService<Color> _colorService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Color>> _genericRepository = new GenericRepositoryMock<Color>()._genericRepository;

            _colorService = new ColorService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionColor()
        {
            //Arrancar
            Color _color = new Color()
            {
                ColorId = 40,
                Nombre = "violeta",
            };

            //Actuar
            bool resultado = await _colorService.Create(_color);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateColor()
        {
            //Arrancar
            Color _color = new Color()
            {
                ColorId = 40,
                Nombre = "violeta",
            };

            //Actuar
            bool resultado = await _colorService.Update(_color);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteColor()
        {
            //Arrancar
            int id = 40;

            //Actuar
            bool resultado = await _colorService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetColor()
        {
            //Arrancar
            int id = 40;

            //Actuar
            var resultado = await _colorService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetColores()
        //{

        //}
    }
}
