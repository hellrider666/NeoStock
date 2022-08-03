using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ProductionEntities
    {
        
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]       
        public float Price { get; set; }
        [Required]
        public UInt32 Amount { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public DepartmentEntities Department { get; set; }
        [Required]
        [MaxLength(100)]
        public string Manufacture { get; set; }       
        [Required]
        public DateTime InsertDate { get; set; } = DateTime.Now;
        
    }
}
