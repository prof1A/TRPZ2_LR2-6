using System;
using System.Collections.Generic;
using BLL;
using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;

namespace TRPZ.Tests
{
    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void GetAll_ValidInvoke_ReturnsCorrectData()
        {
            var repo = new Mock<IGenericRepository<Employee>>();
            repo.Setup(x => x.GetAll()).Returns(new List<Employee>());
            EmployeeService service = new EmployeeService(repo.Object, null);
            

            service.GetAll();

            repo.Verify(x=>x.GetAll());
        }

        [Test]
        public void Create_ValidData_EmployeeCreated()
        {
            var repo = new Mock<IGenericRepository<Employee>>();
            EmployeeService service = new EmployeeService(repo.Object, null);

            var emp = new Developer();
            emp.FirstName = "a";
            emp.LastName = "b";
            emp.Master = new DeliveryManager();
            service.Create(emp);

            repo.Verify(x => x.Create(It.IsAny<Employee>()));
        }

        [Test]
        public void Delete_ValidData_EmployeeDeleted()
        {
            var repo = new Mock<IGenericRepository<Employee>>();
            EmployeeService service = new EmployeeService(repo.Object, null);

            var guid = new Guid();
            service.Delete(guid);

            repo.Verify(x => x.Delete(guid));
        }

        [Test]
        public void Update_ValidData_EmployeeUpdated()
        {
            var repo = new Mock<IGenericRepository<Employee>>();
            EmployeeService service = new EmployeeService(repo.Object, null);

            var emp = new Developer();
            emp.FirstName = "a";
            emp.LastName = "b";
            emp.Master = new DeliveryManager();
            service.Update(emp);

            repo.Verify(x => x.Update(It.IsAny<Employee>()));
        }

    }
}