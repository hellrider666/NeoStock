using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ClientEntities
    {
        public int ID { get; set; } 
        [MaxLength(3)]        
        public string Age { get; set; }
        [MaxLength(18)]        
        public string PhoneNumber { get; set; }        
        public DateTime? DateBorn { get; set; }    
        public DateTime RegDate { get; set; } = DateTime.Now;
        [Required]
        public int ClientIdenID {get; set;}
        public ClientIdentity ClientIden { get; set; }
        public ICollection<CompanyEntities> CompanyEntities { get; set; }
    }
}
