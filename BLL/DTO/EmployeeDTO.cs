using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionWeight { get; set; }
        public string PositionName { get; set; }
        public IEnumerable<EmployeeDTO> Subjects { get; set; }
        public EmployeeDTO Master { get; set; }
        public int Salary { get; set; }
    }
}
