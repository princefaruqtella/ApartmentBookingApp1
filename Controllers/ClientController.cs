using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Service.Interface;
using ApartmentBookingApp1.Dto.Client;
using Microsoft.AspNetCore.Mvc;
using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Data.Enums;
namespace ApartmentBookingApp1.Controllers
{
    public class ClientController(IClientService _clientService, IAccountService _accountService) : Controller
    {
        public IActionResult RegisterClient(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterClientDto clientDto)
        {
             var userDto = new RegisterUserDto{
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Password = clientDto.Password,
                Address = clientDto.Address,
                PhoneNumber = clientDto.PhoneNumber,
                UserType = UserType.Client
            };
            var userResponse = await _accountService.RegisterUser(userDto);


            if(!userResponse.Status){
                return View(userResponse);
            }
            clientDto.UserId = (string)userResponse.response;
            var response = _clientService.RegisterClient(clientDto);
             if(response.Status){
                return RedirectToAction("Login", "Account");
            }
            return View(response);
        }
        public IActionResult GetAllClients(){
        var clients = _clientService.GetAllClients(); 
            return View(clients);
        }
    }
}