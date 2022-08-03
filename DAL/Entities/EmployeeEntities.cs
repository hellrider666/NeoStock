using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class EmployeeEntities
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmpFullName { get; set; }
        [Required]
        [MaxLength(50)]
        public int RoleID { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public DepartmentEntities Department { get; set; }
        [Required]
        [MaxLength(3)]
        public string Age { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;


    }
}
