using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace BLL
{
    public class EmployeeMapper
    {
        public static Employee EmployeeDTOToEmployee(EmployeeDTO employeeDto)
        {
            EmployeeRepository repo = new EmployeeRepository(new ApplicationContext());

            var employee = new Employee
           {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                PositionName = employeeDto.PositionName,
                PositionWeight = employeeDto.PositionWeight,
                Salary =  employeeDto.Salary,
                Id = employeeDto.Id,
                MasterId = employeeDto.Master.Id,
                Subjects = new List<Employee>()
           };

           foreach (var employeeSubject in employee.Subjects)
           {
               employee.Subjects.Add(new Employee{Id = employeeSubject.Id});
           }

           return employee;
        }

        public static EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDto = new EmployeeDTO();

            if (employee.PositionName == "CEO") employeeDto = new CEO();
            if (employee.PositionName == "Delivery Manager") 
                employeeDto = new DeliveryManager();
            if (employee.PositionName == "Sales Manager") employeeDto = new SalesManager();
            if (employee.PositionName == "Developer") 
                employeeDto = new Developer();
            if (employee.PositionName == "Marketer") employeeDto = new Marketer();
            employeeDto.PositionName = employee.PositionName;
            employeeDto.FirstName = employee.FirstName;
            employeeDto.LastName = employee.LastName;
            employeeDto.Id = employee.Id;
            employeeDto.PositionWeight = employee.PositionWeight;
            employeeDto.Salary = employee.Salary;

            //if (employee.Master.PositionName == "CEO") employeeDto.Master = new CEO();
            //if (employee.Master.PositionName == "DeliveryManager") employeeDto.Master = new DeliveryManager();
            //if (employee.Master.PositionName == "SalesManager") employeeDto.Master = new SalesManager();
            //if (employee.Master.PositionName == "Developer") employeeDto.Master = new Developer();
            //if (employee.Master.PositionName == "Marketer") employeeDto.Master = new Marketer();
            if (employeeDto is CEO == false)
            {

                employeeDto.Master.PositionName = employee.Master.PositionName;
                employeeDto.Master.FirstName = employeeDto.Master.FirstName;
                employeeDto.Master.LastName = employeeDto.Master.LastName;
                employeeDto.Master.Id = employeeDto.Master.Id;
                employeeDto.Master.PositionWeight = employeeDto.Master.PositionWeight;
            }

            if (employeeDto is Worker == false)
            {
                employeeDto.Subjects = new List<EmployeeDTO>();
                if (employee.Subjects != null)
                {
                    foreach (var em in employee.Subjects)
                    {

                        if (em.PositionName == "CEO") ((List<EmployeeDTO>)employeeDto.Subjects).Add(new CEO());
                        if (em.PositionName == "Delivery Manager") ((List<EmployeeDTO>)employeeDto.Subjects).Add(new DeliveryManager());
                        if (em.PositionName == "Sales Manager") ((List<EmployeeDTO>)employeeDto.Subjects).Add(new SalesManager());
                        if (em.PositionName == "Developer") ((List<EmployeeDTO>)employeeDto.Subjects).Add(new Developer());
                        if (em.PositionName == "Marketer") ((List<EmployeeDTO>)employeeDto.Subjects).Add(new Marketer());
                        employeeDto.Subjects.Last().Id = em.Id;
                        employeeDto.Subjects.Last().FirstName = em.FirstName;
                        employeeDto.Subjects.Last().LastName = em.LastName;
                        employeeDto.Subjects.Last().PositionName = em.PositionName;
                        employeeDto.Subjects.Last().PositionWeight = em.PositionWeight;
                    }
                }
            }

            return employeeDto;


        }
    }
}
