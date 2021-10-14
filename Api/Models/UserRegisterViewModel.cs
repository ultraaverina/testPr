using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(250)]
        public string FIO { get; set; }

        [Required]
        [RegularExpression(@"7[0-9]{10}", ErrorMessage = "Некорректный номе телефона")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        //FIO ФИО строка Да  Нет	250	-
        //Phone Номер телефона строка  Да Да	11	Только цифры, начинается с "7"
        //Email Email   строка Да  Да	150	Валидация для email
        //Password    Пароль строка  Да Нет	20	-
        //PasswordConfirm Подтверждение пароля строка  Да Нет	20	должно совпадать с полем Password
    }
}
