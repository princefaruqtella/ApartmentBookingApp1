using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Dto.Client;
using ApartmentBookingApp1.Models;
using ApartmentBookingApp1.Repositories.Interfaces;
using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Identity;


namespace ApartmentBookingApp1.Service.Implementation
{
    public class ClientService(IClientRepository _clientRepository, UserManager<User> _userManager) : IClientService
    {
        public BaseResponse RegisterClient(RegisterClientDto clientDto)
        {
           
            var client = new Client
            {
                UserId = clientDto.UserId,              
                NextOfKinName = clientDto.NextOfKinName,
                NextOfKinPhoneNumber = clientDto.NextOfKinPhoneNumber,
                NextOfKinAddress = clientDto.NextOfKinAddress
            };
           int changes = _clientRepository.AddClient(client);
            if(changes < 0)
            {
                return new BaseResponse(false, "500", "An error occured, Pls try again");
            }
            return new BaseResponse(true, "200", "Registeration successful");
        }
        public async  Task<List<ClientDto>> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            List<ClientDto> clientDto = new();
            foreach (var x in clients)
             {
                var user = await _userManager.FindByIdAsync(x.UserId);
                clientDto.Add(new ClientDto{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = x.User.Address,
                PhoneNumber = x.User.PhoneNumber,
                NextOfKinName = x.NextOfKinName,
                NextOfKinPhoneNumber = x.NextOfKinPhoneNumber,
                NextOfKinAddress = x.NextOfKinAddress
            });
            }
            return clientDto;
        }
    }
}