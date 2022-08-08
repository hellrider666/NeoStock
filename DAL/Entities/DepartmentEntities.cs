using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class DepartmentEntities
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public CompanyEntities Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public int DepartTypeId { get; set; }
        [Required]
        public DepartmentTypesEntities DepartType { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortAddress { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        EmployeeEntities Employee { get; set; }
        ICollection<ProductionEntities> ProductionEntities { get; set; }
    }
}
