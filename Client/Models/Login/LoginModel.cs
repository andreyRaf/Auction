using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Ваше имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ваш почтовый ящик")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(800)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleID { get; set; }
        public string vkID { get; set; }
    }
}