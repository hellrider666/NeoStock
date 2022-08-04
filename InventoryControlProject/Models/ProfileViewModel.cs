using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlProject.Models
{
    public class ProfileViewModel
    {
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime RegDate { get; set; }
        public string FullName { get; set; }
        public ClientIdentity clientIdentity { get; set; }
    }
}
