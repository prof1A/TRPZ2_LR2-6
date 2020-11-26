using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public abstract class Manager:EmployeeDTO
    {
        protected Manager()
        {
            PositionWeight = 2;
            Subjects = new List<Worker>();
        }
    }
}
