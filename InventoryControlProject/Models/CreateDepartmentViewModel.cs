using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlProject.Models
{
    public class CreateDepartmentViewModel
    {
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public string ShortAddress { get; set; }
        public string Description { get; set; }
    }
}
