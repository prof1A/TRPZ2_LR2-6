using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Util
{
    public class Visitor : IVisitor
    {
        private readonly IEmployeeService _employeeService;
        public List<CEO> Ceos { get; set; }
        public List<DeliveryManager> DeliveryManagers { get; set; }
        public List<SalesManager> SalesManagers { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Marketer> Marketers { get; set; }

        public Visitor(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Ceos = new List<CEO>();
            _employeeService.GetAll().Where(x => x.PositionName == "CEO").ToList().ForEach(x => Ceos.Add(x as CEO));

            DeliveryManagers = new List<DeliveryManager>();
            _employeeService.GetAll().Where(x => x.PositionName == "Delivery Manager").ToList().ForEach(x => DeliveryManagers.Add(x as DeliveryManager));

            SalesManagers = new List<SalesManager>();
            _employeeService.GetAll().Where(x => x.PositionName == "Sales Manager").ToList().ForEach(x => SalesManagers.Add(x as SalesManager));

            Developers = new List<Developer>();
            _employeeService.GetAll().Where(x => x.PositionName == "Developer").ToList().ForEach(x => Developers.Add(x as Developer));
           
            Marketers = new List<Marketer>();
            _employeeService.GetAll().Where(x => x.PositionName == "Marketer").ToList().ForEach(x => Marketers.Add(x as Marketer));
           
        }

        public void CreateNewEmployee(string firstName, string lastName, string position, Guid masterid)
        {
            var employee = new EmployeeDTO{FirstName = firstName, LastName = lastName, PositionName = position, Master = new EmployeeDTO{Id = masterid}};
            _employeeService.Create(employee);
        }
    }
}
