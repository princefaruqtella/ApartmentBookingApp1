using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Dto
{
    public class RegisterUserDto
    {
         [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and confirm password must match")]
        public string ConfirmPassword { get; set; }
    }
}