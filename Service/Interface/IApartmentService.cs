using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Dto.Client;
using ApartmentBookingApp1.Models;

namespace ApartmentBookingApp1.Service.Interface
{
    public interface IApartmentService
    {
        BaseResponse RegisterApartment(RegisterApartmentDto apartmentDto);
        Task<List<ApartmentDto>> GetAllApartments();
    }
}
