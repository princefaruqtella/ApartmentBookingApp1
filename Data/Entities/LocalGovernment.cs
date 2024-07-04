using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Data.Entities
{
    public class LocalGovernment : BaseEntity
    {
        public string LocalGovernmentName { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}