using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Util
{
    public class Composite : IComposite
    {
        private readonly IEmployeeService _employeeService;

        public Composite(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public string GetAllInTreeView()
        {
            var employees = _employeeService.GetAll().ToList().OrderBy(x => x.PositionWeight);
            string res = "";
            res += "CEO: " + employees.First().LastName + " " + employees.First().FirstName +"\n";
            foreach (var manager in employees.Where(x => x.PositionWeight == 2))
            {
                res += $"---{manager.PositionName}: {manager.LastName} {manager.FirstName}\n";
                foreach (var slave in manager.Subjects)
                {
                    res += $"---------{slave.PositionName}: {slave.LastName} {slave.FirstName}\n";
                }

            }

            return res;
        }
    }
}