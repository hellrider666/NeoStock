using DAL.Entities;
using LOGIC.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IAuthService
    {     
        public bool Auth(AuthDTO user);
        public void Authenticate(ClientIdentity user);
    }
}
