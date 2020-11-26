using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Developer: Worker
    {
        public Developer()
        {
            Master = new DeliveryManager();
            PositionName = "Developer";
        }
    }
}
