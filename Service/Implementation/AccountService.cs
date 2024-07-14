using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Data.Enums;
using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Models;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace ApartmentBookingApp1.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<BaseResponse> LoginUser(LoginUserDto request)
        {
            var loginUser = await _userManager.FindByEmailAsync(request.Email);

            if (loginUser == null)
            {
                return new BaseResponse(false, "404", "Invalid email or password");
            }
            var response = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);

            if (response.Succeeded)
            {

                return new BaseResponse(true, "001", "Login Successfully");
            }

            return new BaseResponse(false, "004", "invalid username or password");
        }

        public async Task<BaseResponse> RegisterUser(RegisterUserDto request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                Address = request.Address,
                UserType = request.UserType,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true
            };

            var createUser = await _userManager.CreateAsync(user, request.Password);
            Console.WriteLine(createUser);

            if (createUser.Succeeded)
            {
                return new BaseResponse(true, "200", "Registration Successfully", response: user.Id);
            }

            return new BaseResponse(false, "400", "Registration Failed");
        }
    }
}
