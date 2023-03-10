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
    public class GrupoServiceTest
    {
        private static IGenericService<Grupo> _grupoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Grupo>> _genericRepository = new GenericRepositoryMock<Grupo>()._genericRepository;

            _grupoService = new GrupoService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionGrupo()
        {
            //Arrancar
            Grupo _grupo = new Grupo()
            {
                GrupoId = 5,
                Nombre = "Combo 1",
            };

            //Actuar
            bool resultado = await _grupoService.Create(_grupo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateGrupo()
        {
            //Arrancar
            Grupo _grupo = new Grupo()
            {
                GrupoId = 5,
                Nombre = "Combo 2",
            };

            //Actuar
            bool resultado = await _grupoService.Update(_grupo);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteGrupo()
        {
            //Arrancar
            int id = 5;

            //Actuar
            bool resultado = await _grupoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetGrupo()
        {
            //Arrancar
            int id = 40;

            //Actuar
            var resultado = await _grupoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetGrupos()
        //{

        //}
    }
}
