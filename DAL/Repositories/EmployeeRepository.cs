using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeRepository: IGenericRepository<Employee>
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            _context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }
    }
}
