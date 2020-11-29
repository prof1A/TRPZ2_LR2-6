using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TRPZ_2_LR_2_6.Controllers;

namespace TRPZ.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ValidInvoke_NotNull()
        {
            var service = new Mock<IEmployeeService>();
            var visitor = new Mock<IVisitor>();
            var composite = new Mock<IComposite>();
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO>
                {new EmployeeDTO {FirstName = "fname", LastName = "lname", PositionName = "CEO"}});
            HomeController controller = new HomeController(service.Object, visitor.Object, composite.Object);

            var res = controller.Index() as ViewResult;

            Assert.NotNull(res);
        }

        [Test]
        public void EmployeeById_CorrectId_EmployeeFound()
        {
            var service = new Mock<IEmployeeService>();
            var visitor = new Mock<IVisitor>();
            var composite = new Mock<IComposite>();
            var id = Guid.NewGuid();
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO>
                {new EmployeeDTO {FirstName = "fname", LastName = "lname", PositionName = "CEO", Id = id}});
            HomeController controller = new HomeController(service.Object, visitor.Object, composite.Object);

            var res = controller.EmployeeById(id) as ViewResult;

            Assert.AreEqual(id,(res.Model as EmployeeDTO).Id);
        }

        [Test]
        public void AllEmployees_Correct_EmployeesReturned()
        {
            var service = new Mock<IEmployeeService>();
            var visitor = new Mock<IVisitor>();
            var composite = new Mock<IComposite>();
            var id = Guid.NewGuid();
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO>
                {new EmployeeDTO {FirstName = "fname", LastName = "lname", PositionName = "CEO", Id = id}});
            HomeController controller = new HomeController(service.Object, visitor.Object, composite.Object);

            var res = controller.AllEmployees() as ViewResult;

            Assert.AreEqual(1, (res.Model as IEnumerable<EmployeeDTO>).Count());
        }

        [Test]
        public void CreateEmployeeGet_Correct_NotNull()
        {
            var service = new Mock<IEmployeeService>();
            var visitor = new Mock<IVisitor>();
            var composite = new Mock<IComposite>();
            var id = Guid.NewGuid();
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO>
                {new EmployeeDTO {FirstName = "fname", LastName = "lname", PositionName = "CEO", Id = id}});
            HomeController controller = new HomeController(service.Object, visitor.Object, composite.Object);

            var res = controller.CreateEmployee() as ViewResult;

            Assert.NotNull(res);
        }

        [Test]
        public void CreateEmployeePost_Correct_NotNull()
        {
            var service = new Mock<IEmployeeService>();
            var visitor = new Mock<IVisitor>();
            var composite = new Mock<IComposite>();
            var id = Guid.NewGuid();
            service.Setup(x => x.GetAll()).Returns(new List<EmployeeDTO>
                {new EmployeeDTO {FirstName = "fname", LastName = "lname", PositionName = "CEO", Id = id}});
            HomeController controller = new HomeController(service.Object, visitor.Object, composite.Object);

            var res = controller.CreateEmployee("test","test","Delivery Manager",id) as ViewResult;

            visitor.Verify(x=>x.CreateNewEmployee("test","test", "Delivery Manager", It.IsAny<Guid>()));
        }
    }
}
