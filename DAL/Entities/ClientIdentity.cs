using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ClientIdentity
    {
        public int ID { get; set; }
        [MaxLength(20)]
        [Required]
        public string Login { get; set; }
        [MaxLength(25)]
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;
        [Required]
        public int RoleId {get; set;}
        [Required]
        public Roles Role { get; set; }      
        [Required]
        public ClientEntities ClientEntity { get; set; }
    }
}
