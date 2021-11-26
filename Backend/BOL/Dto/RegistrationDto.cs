using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Dto
{
    public class RegistrationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Must more than 3 character long.")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
