using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DTO
{
    public class ClientEntitiesDTO
    {                            
        public string Age { get; set; }
        public string PhoneNumber { get; set; }      
        public DateTime DateBorn { get; set; }       
        public DateTime RegDate { get; set; }
        public ClientIdentity ClientIdentity { get; set; }
    }
}
