using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using ApartmentBookingApp1.Dto.Client;
using ApartmentBookingApp1.Data.Enums;

namespace ApartmentBookingApp1.Controllers
{
    public class ApartmentController(IApartmentService _apartmentService) : Controller
    {
        public IActionResult RegisterApartment(){
            return View();
        } 
    
        [HttpPost]
        public async Task<IActionResult> RegisterApartment(RegisterApartmentDto apartmentDto)
        {
            var response = _apartmentService.RegisterApartment(apartmentDto);
             if(response.Status){
                //return RedirectToAction("GetAllApartments");
            }
            return View(response);
        }
        public async Task<IActionResult> GetAllApartments(){
        var clients = await _apartmentService.GetAllApartments(); 
            return View(clients);
        }
         
    }
}
