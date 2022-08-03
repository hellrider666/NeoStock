using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CompanyEntities
    {
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string CompanyName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }
        [MaxLength(50)]
        [Required]
        public string ShortAddress { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public ClientEntities clientEntities { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;
        [Required]
        public int EnterpriseTypeID { get; set; }
        [Required]
        public EnterpriseEntities enterpriseEntity { get; set; }
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }
        ICollection<DepartmentEntities> DepartmentEntities { get; set; }
        
        

    }
}
