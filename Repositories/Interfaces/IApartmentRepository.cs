using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Data.Entities;

namespace ApartmentBookingApp1.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        int AddApartment(Apartment apartment);
        List<Apartment> GetAllApartments();
    }
}