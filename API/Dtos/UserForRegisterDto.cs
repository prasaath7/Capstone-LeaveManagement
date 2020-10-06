using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength =4,ErrorMessage ="Characters must be 4 to 8")]
        public string Password { get; set; }    

        [Required]
        [EmailAddress]  
        public string Email { get; set; }
    }
}
