using DAL.Entities;
using LOGIC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Interfaces
{
    public interface IRegistrationService
    {
        public bool CreateUser(RegistrationDTO user);      
        
    }
}
