using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Data;
using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Repositories.Interfaces;
namespace ApartmentBookingApp1.Repositories
{
    public class ApartmentRepository(ApplicationDbContext _context) : IApartmentRepository
    {
        public int AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            return _context.SaveChanges();
        }
        public List<Apartment> GetAllApartments()
        {
            return _context.Apartments.ToList();
        }
    }
}


// {
//     public class ApartmentRepository(ApplicationDbContext _context) : IApartmentRepository
//     {
//         private readonly ApplicationDbContext _context;

//         public ApartmentRepository(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public int AddApartment(Apartment apartment)
//         {
//             _context.Apartments.Add(apartment);
//             return _context.SaveChanges();
//         }

//         public async Task<List<Apartment>> GetAllApartmentsAsync()
//         {
//             return await _context.Apartments.ToListAsync();
//         }
//     }
// }