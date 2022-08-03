using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlProject.Models
{
    public class ClientEntitiesViewModel
    {          
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegDate { get; set; }
        public ClientIdentity ClientIdentity { get; set; }
    }

}
