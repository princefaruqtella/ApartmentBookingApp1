using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Data.Entities
{
    public class State : BaseEntity
    {
        public string StateName { get; set; }

        public ICollection<LocalGovernment> LocalGovernments { get; set; }
    }
}