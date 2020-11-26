using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SalesManager: Manager
    {
        public SalesManager()
        {
            Master = new CEO();
            PositionName = "Sales Manager";
            Subjects = new List<Marketer>();
        }
    }
}
