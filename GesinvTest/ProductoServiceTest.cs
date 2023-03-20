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
    public class ProductoServiceTest
    {
        private static IProductoService _productoService;
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //este metodo (Setup) instancia la clase ProductoRepositoryMock y su valor por referencia va ser _productoRepository
            //InjectMock???
            Mock<IProductoRepository> _productoRepository = new ProductoRepositoryMock()._productoRepository;

            //Insercion de dependencias. Aca indico que cuando instancie la clase ProductoService me traiga un objeto de _productoRepository.
            //Este Object indica en memoria que va a traer un objeto de tipo prueba.
            //Mock
            _productoService = new ProductoService(_productoRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionProducto()
        {
            //Arrancar
            Producto _producto = new Producto()
            {
                ProductoId = 40,
                Nombre = "Calabaza",
                Unidad = 20,
                Activo = false,
                Perecible = true,
                Iva = false,
                Precio = 2,
                LineaId = 2,
                TipoId = 2,
                GrupoId = 3,
                MarcaId = 1,
                MedidaId = 2,
                Comentario = "Nuevo",
                Caja = 2,
                FechaCaducidad = DateTime.Now,


            };

            //Actuar
            bool resultado = await _productoService.Create(_producto);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateProducto()
        {
            //Arrancar
            Producto _producto = new Producto()
            {
                ProductoId = 40,
                Nombre = "Calabaza",
                Unidad = 20,
                Activo = false,
                Perecible = true,
                Iva = false,
                Precio = 2,
            };

            //Actuar
            bool resultado = await _productoService.Update(_producto);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteProducto()
        {
            //Arrancar
            int id = 4;

            //Actuar
            bool resultado = await _productoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetProducto()
        {
            //Arrancar
            int id = 4;

            //Actuar
            var resultado = await _productoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetProductos()
        //{

        //}

        [TestMethod]
        public async void valida_GetColors()
        {
            //Arrancar
            int id = 4;

            //Actuar
            var resultado = await _productoService.GetColors(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

    }
}
