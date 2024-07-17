using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentBookingApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDto request)
        {
            var response = await _accountService.RegisterUser(request);

            if (response.Status)
            {
                return View();
            }
            return RedirectToAction("RegisterUser");
            
        }  

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto request)
        {
            var response = await _accountService.LoginUser(request);

            if (response.Status)
            {
                if(response.response != null){
                    return RedirectToAction("GetAllApartments", "Apartment");
                }
                return RedirectToAction("Index","Home");
            }

            return View(response);
        }
    }
}
