using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly DbInitializer _initializer;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, DbInitializer initializer)
        {
            _employeeRepository = employeeRepository;
            _initializer = initializer;
            if(_initializer != null)
                _initializer.Initialize();
        }

        public void Create(EmployeeDTO obj)
        {

            var emp = EmployeeMapper.EmployeeDTOToEmployee(obj);
            _employeeRepository.Create(emp);
        }

        public void Delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }

        public void Update(EmployeeDTO obj)
        {
            var emp = EmployeeMapper.EmployeeDTOToEmployee(obj);
            _employeeRepository.Update(emp);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var list = new List<EmployeeDTO>();
            foreach (var i in _employeeRepository.GetAll().ToList())
            {
                var emp = EmployeeMapper.EmployeeToEmployeeDTO(i);
                list.Add(emp);
            }

            return list;
        }
    }
}
