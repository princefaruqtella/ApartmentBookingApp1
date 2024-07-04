using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace ApartmentBookingApp1.Data.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
    }
}
