using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CEO :EmployeeDTO
    {
        public CEO()
        {
            PositionName = "CEO";
            PositionWeight = 1;
            Subjects = new List<Manager>();
            Master = this;
        }
    }
}
