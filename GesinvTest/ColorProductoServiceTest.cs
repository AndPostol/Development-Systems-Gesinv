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
    public class ColorProductoServiceTest
    {
        private static IColorProductoService _colorProductoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IColorProductoRepository> _colorProductoRepository = new ColorProductoRepositoryMock()._colorProductoRepository;

            _colorProductoService = new ColorProductoService(_colorProductoRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionColorProducto()
        {
            //Arrancar
            ColorProducto _colorProducto = new ColorProducto()
            {
                ColorProductoId = 15,
                ColorId = 1,
                ProductoId = 2,
            };

            //Actuar
            bool resultado = await _colorProductoService.Create(_colorProducto);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateColorProducto()
        {
            //Arrancar
            ColorProducto _colorProducto = new ColorProducto()
            {
                ColorProductoId = 15,
                ColorId = 5,
                ProductoId = 3,
            };

            //Actuar
            bool resultado = await _colorProductoService.Update(_colorProducto);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteColorProducto()
        {
            //Arrancar
            int id = 15;

            //Actuar
            bool resultado = await _colorProductoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetBodega()
        {
            //Arrancar
            int id = 2;

            //Actuar
            var resultado = await _colorProductoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetColorProductos()
        //{

        //}
    }
}
