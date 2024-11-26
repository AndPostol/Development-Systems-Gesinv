using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic;
using DevSys.Gesinv.Models;
using Moq;

namespace DevSys.Gesinv.Unit.Test.MockRepository
{
    public class OrdenCompraRepositoryMock
    {
        public Mock<IOrdenCompraRepository> _ordenCompraRepository { get; set; }

        public OrdenCompraRepositoryMock()
        {
            _ordenCompraRepository = new Mock<IOrdenCompraRepository>();
        }
    }
}
