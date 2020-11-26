using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        void Create(EmployeeDTO obj);
        void Delete(Guid id);
        void Update(EmployeeDTO obj);
        IEnumerable<EmployeeDTO> GetAll();
    }
}