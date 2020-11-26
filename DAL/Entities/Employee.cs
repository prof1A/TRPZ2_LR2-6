using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionWeight { get; set; }
        public string PositionName { get; set; }
        public List<Employee> Subjects { get; set; }
        public Guid? MasterId { get; set; }
        public Employee Master { get; set; }
        public int Salary { get; set; }

    }
}
