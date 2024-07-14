using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Data;
using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Repositories.Interfaces;
namespace ApartmentBookingApp1.Repositories
{
    public class ClientRepository(ApplicationDbContext _context) : IClientRepository
    {
        public int AddClient(Client client)
        {
            _context.Clients.Add(client);
            return _context.SaveChanges();
        }
        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }
    }
}