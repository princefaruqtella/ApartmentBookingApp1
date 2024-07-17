using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Models;
using ApartmentBookingApp1.Dto.Client;
namespace ApartmentBookingApp1.Service.Interface
{
    public interface IClientService
    {
        BaseResponse RegisterClient(RegisterClientDto clientDto);
        Task<List<ClientDto>> GetAllClients();
    }
}

