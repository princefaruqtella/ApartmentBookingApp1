using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Dto.Client
{
    public class RegisterApartmentDto
    {
        public string Address { get; set; }
        public string LocalGovernment { get; set; }
        public decimal ApartmentPrice { get; set; }
        public decimal OtherCharges { get; set; }
        public int NumberOfRooms { get; set; }
        public IFormFile Image { get; set; } 
    }
}