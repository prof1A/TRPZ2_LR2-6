using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using TRPZ_2_LR_2_6.Models;

namespace TRPZ_2_LR_2_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IVisitor _visitor;
        private readonly IComposite _composite;

        public HomeController(IEmployeeService employeeService, IVisitor visitor, IComposite composite)
        {
            _employeeService = employeeService;
            _visitor = visitor;
            _composite = composite;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_employeeService.GetAll().First(x => x.PositionName == "CEO"));
        }

        [HttpGet]
        public IActionResult EmployeeById(Guid id)
        {
            return View("Index",_employeeService.GetAll().First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult AllEmployees(string position = "all", string sortedBy = "all", int salary = 0, string search="")
        {
            var employees = _employeeService.GetAll();


            if (position == "ceo")
            {
                employees = employees.Where(x => x.PositionName == "CEO");
            }
            if (position == "deliverymanager")
            {
                employees = employees.Where(x => x.PositionName == "Delivery Manager");
            }
            if (position == "salesmanager")
            {
                employees = employees.Where(x => x.PositionName == "Sales Manager");
            }
            if (position == "developer")
            {
                employees = employees.Where(x => x.PositionName == "Developer");
            }
            if (position == "marketer")
            {
                employees = employees.Where(x => x.PositionName == "Marketer");
            }



            if (sortedBy == "lastname")
            {
                employees = employees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            }

            if (sortedBy == "lastname")
            {
                employees = employees.OrderBy(x => x.LastName);
            }
            if (sortedBy == "salary")
            {
                employees = employees.OrderByDescending(x => x.Salary);
            }
            if (sortedBy == "position")
            {
                employees = employees.OrderBy(x => x.PositionWeight);
            }



            if (search != null)
            {
                employees = employees.Where(x => x.LastName.Contains(search));
            }

            if (salary > 0)
            {
                employees = employees.Where(x => x.Salary > salary);
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var model = new CreateEmployeeViewModel();
            model.Masters = _employeeService.GetAll().Where(x =>
                x.PositionName == "CEO" || 
                x.PositionName == "Sales Manager" || 
                x.PositionName == "Delivery Manager")
                .ToList();

            model.Positions = _employeeService.GetAll().Where(x=>x.PositionName!="CEO").Select(x => x.PositionName).Distinct().ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateEmployee(string firstname, string lastname, string positionname, Guid masterid)
        {
            EmployeeDTO employee = new EmployeeDTO();
            if (positionname == "Developer")
            {
                employee = new Developer();
            }

            if (positionname == "Marketer")
            {
                employee = new Marketer();
            }

            if (positionname == "Sales Manager")
            {
                employee = new SalesManager();
            }

            if (positionname == "Delivery Manager")
            {
                employee = new DeliveryManager();
            }

            var masterPosition = _employeeService.GetAll().First(x => x.Id == masterid).PositionName;
            if (employee.Master.PositionName != masterPosition)
            {
                throw new ArgumentException("aaaaa");
            }


            employee.FirstName = firstname;
            employee.LastName = lastname;
            employee.PositionName = positionname;
            employee.Master = _employeeService.GetAll().First(x => x.Id == masterid);


            if (positionname.Contains("Manager")) employee.PositionWeight = 2;
            else employee.PositionWeight = 3;

            Random rnd = new Random();
            employee.Salary = rnd.Next(1000, 2000);

            employee.Id = Guid.NewGuid();
            

            _visitor.CreateNewEmployee(firstname, lastname, positionname, masterid);
            //_employeeService.Create(employee);
            return RedirectToAction("Index", "Home");
        }
    }
}
