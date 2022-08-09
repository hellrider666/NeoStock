using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DTO
{
    public class CreateCompanyDTO
    {
        public string CompanyName { get; set; }        
        public string Address { get; set; }        
        public string ShortAddress { get; set; }         
        public string Description { get; set; }       
    }
}
