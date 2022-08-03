using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DTO
{
    public class AuthDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
