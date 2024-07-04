using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Data.Enums;
using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Models;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace ApartmentBookingApp1.Service
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
                return new BaseResponse(false, "001", "invalid username or password");
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
                Id = Guid.NewGuid().ToString(),
                UserName = request.Email,
                Email = request.Email,
                Address = request.Address,
                FullName = request.FullName,
                UserType = UserType.Admin,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = true
            };

            var createUser = await _userManager.CreateAsync(user, request.ConfirmPassword);

            if (createUser.Succeeded)
            {
                return new BaseResponse(true, "001", "Registration Successfully");
            }

            return new BaseResponse(false, "004", "Registration Failed");
        }
    }
}
