using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;

namespace TRPZ_2_LR_2_6.Models
{
    public class CreateEmployeeViewModel
    {
        public List<string> Positions { get; set; }
        public List<EmployeeDTO> Masters { get; set; }
    }
}
