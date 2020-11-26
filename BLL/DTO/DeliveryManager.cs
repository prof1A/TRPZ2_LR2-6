using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DeliveryManager: Manager
    {
        public DeliveryManager()
        {
            Master = new CEO();
            PositionName = "Delivery Manager";
            Subjects = new List<Developer>();
        }
    }
}
