using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UserLoginViewModel
    {
        [Required]
        [RegularExpression(@"7[0-9]{10}", ErrorMessage = "Некорректный номе телефона")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
