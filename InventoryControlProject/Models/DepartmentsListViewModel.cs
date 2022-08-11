using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlProject.Models
{
    public class DepartmentsListViewModel
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public string ShortAddress { get; set; }
        public string TypeName { get; set; }
    }
}
