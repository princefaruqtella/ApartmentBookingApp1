using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBookingApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("register-user")]
        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto request)
        {
            var response = await _accountService.RegisterUser(request);

            if (response.Status)
            {
                return View();
            }
            return RedirectToAction("RegisterUser");
            
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto request)
        {
            var response = await _accountService.LoginUser(request);

            if (response.Status)
            {
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("login");
        }
    }
}
