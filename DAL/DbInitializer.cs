using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            if (_context.Employees.Any()) return;

            var ceo = new Employee
            {
                FirstName = "Andrey",
                LastName = "Patau",
                PositionName = "CEO",
                PositionWeight = 1,
                Subjects = new List<Employee>(),
                Salary = 5000
            };

            var manager1 = new Employee
            {
                FirstName = "Arthur",
                LastName = "Glack",
                PositionName = "Delivery Manager",
                PositionWeight = 2,
                Master = ceo,
                Subjects = new List<Employee>(),
                Salary = 3400
            };

            var manager2 = new Employee
            {
                FirstName = "Tyler",
                LastName = "Durden",
                PositionName = "Delivery Manager",
                PositionWeight = 2,
                Master = ceo,
                Subjects = new List<Employee>(),
                Salary = 3200
            };

            var manager3 = new Employee
            {
                FirstName = "Forrest",
                LastName = "Gump",
                PositionName = "Sales Manager",
                PositionWeight = 2,
                Master = ceo,
                Subjects = new List<Employee>(),
                Salary = 2900
            };

            var employee1 = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                PositionName = "Developer",
                PositionWeight = 3,
                Master = manager1,
                Salary = 2900
            };
            var employee2 = new Employee
            {
                FirstName = "Tomas",
                LastName = "Angelo",
                PositionName = "Developer",
                PositionWeight = 3,
                Master = manager1,
                Salary = 1500
            };
            var employee3 = new Employee
            {
                FirstName = "Ilariy",
                LastName = "Singer",
                PositionName = "Developer",
                PositionWeight = 3,
                Master = manager1,
                Salary = 1900
            };
            var employee4 = new Employee
            {
                FirstName = "Vito",
                LastName = "Scaletta",
                PositionName = "Developer",
                PositionWeight = 3,
                Master = manager2,
                Salary = 2300
            };
            var employee5 = new Employee
            {
                FirstName = "Andrew",
                LastName = "Glack",
                PositionName = "Developer",
                PositionWeight = 3,
                Master = manager2,
                Salary = 2000
            }; var employee6 = new Employee
            {
                FirstName = "John",
                LastName = "Nojohn",
                PositionName = "Marketer",
                PositionWeight = 3,
                Master = manager3,
                Salary = 1700
            }; 
            var employee7 = new Employee
            {
                FirstName = "Joe",
                LastName = "Barbaro",
                PositionName = "Marketer",
                PositionWeight = 3,
                Master = manager3,
                Salary = 1150
            };
            var employee8 = new Employee
            {
                FirstName = "Afanasiy",
                LastName = "Doe",
                PositionName = "Marketer",
                PositionWeight = 3,
                Master = manager3,
                Salary = 1300
            };
            var employee9 = new Employee
            {
                FirstName = "Kirill",
                LastName = "Llirik",
                PositionName = "Marketer",
                PositionWeight = 3,
                Master = manager3,
                Salary = 1000
            };


            _context.Employees.AddRange(new List<Employee>
            {
                ceo, manager1, manager2, manager3, employee1, employee2, employee3, employee4, employee5, employee6, employee7, employee8, employee9
            });

            _context.SaveChanges();



        }
    }
}
