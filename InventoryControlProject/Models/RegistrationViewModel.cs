using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlProject.Models
{
    public class RegistrationViewModel
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указано ФИО!")]
        public string FullName { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Не указана почта!")]
        public string Email { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Не указан Логин!")]
        public string Login { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "Не указан Пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
