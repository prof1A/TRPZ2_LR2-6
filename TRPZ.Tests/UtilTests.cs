using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Util;
using DAL.Entities;
using Moq;
using NUnit.Framework;

namespace TRPZ.Tests
{
    [TestFixture]
    public class UtilTests
    {
        [Test]
        public void CompositeGetAllInTreeView_CorrectData_ReturnTree()
        {
            var service = new Mock<IEmployeeService>();
            Composite composite = new Composite(service.Object);
            var ceo = new CEO{FirstName = "test1", LastName = "test1"};
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO> {ceo});

            var res = composite.GetAllInTreeView();

            Assert.AreEqual("CEO: test1 test1\n", res);

        }

        [Test]
        public void VisitorCreateNewEmployee_CorrectData_EmployeeCreated()
        {
            var service = new Mock<IEmployeeService>();
            Visitor visitor = new Visitor(service.Object);
            
            var guid = new Guid();
            visitor.CreateNewEmployee("test","test","test",guid);

            service.Verify(x=>x.Create(It.IsAny<EmployeeDTO>()));
        }
    }
}
