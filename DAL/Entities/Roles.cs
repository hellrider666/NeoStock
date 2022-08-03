using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Roles
    {
        public int ID { get; set; }
        [MaxLength(20)]
        [Required]
        public string RoleName { get; set; }
        [MaxLength(255)]
        [Required]
        public string RoleDescription { get; set; }
        public ICollection<ClientIdentity> clientIdentities { get; set; }
        public ICollection<EmployeeEntities> EmployeeEntities { get; set; }
    }
}
