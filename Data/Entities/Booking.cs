using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Data.Entities
{
    public class Booking : BaseEntity
    {
        public Guid AparmentId { get; set; }
        public Apartment Apartment { get; set; }
        public bool IsPaid { get; set; }
    }
}