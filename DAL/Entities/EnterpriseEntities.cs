using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class EnterpriseEntities
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string EnterpriseName { get; set; }
        [Required]
        [MaxLength(255)]
        public string EnterpriseDescription { get; set; }
        public ICollection<CompanyEntities> CompanyEntities { get; set; }
    }
}
