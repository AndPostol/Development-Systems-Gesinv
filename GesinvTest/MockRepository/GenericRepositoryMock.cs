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

namespace DevSys.Gesinv.Unit.Test.MockRepository
{
    public class GenericRepositoryMock<T> where T : class
    {
        public Mock<IGenericRepository<T>> _genericRepository { get; set; }

        public GenericRepositoryMock()
        {
            _genericRepository = new Mock<IGenericRepository<T>>();
        }
    }
}
