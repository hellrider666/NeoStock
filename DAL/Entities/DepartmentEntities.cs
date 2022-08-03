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
        public CompanyEntities CompanyEntity { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortAddress { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        ICollection<EmployeeEntities> EmployeeEntities { get; set; }
        public ProductionEntities ProductionEntities { get; set; }
    }
}
