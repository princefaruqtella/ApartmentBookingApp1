using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApartmentBookingApp1.Dto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}