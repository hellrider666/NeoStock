using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class DepartmentTypesEntities
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public ICollection<DepartmentEntities> departments { get; set; }
    }
}
