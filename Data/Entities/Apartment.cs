using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Data.Enums;

namespace ApartmentBookingApp1.Data.Entities
{
    public class Apartment : BaseEntity
    {
        public ApartmentType ApartmentType { get; set; }
        public string Address { get; set; }
        public int LocalGovernmentId { get; set; }
        public LocalGovernment LocalGovernment { get; set; }
        public decimal ApartmentPrice { get; set; }
        public decimal OtherCharges { get; set; }
        public byte[] Image { get; set; } 
    }
}