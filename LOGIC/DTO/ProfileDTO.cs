using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DTO
{
    public class ProfileDTO
    {
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime RegDate { get; set; }
        public string FullName { get; set; }
        public ClientIdentity clientIdentity { get; set; }
    }
}
