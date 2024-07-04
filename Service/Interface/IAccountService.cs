using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Models;

namespace ApartmentBookingApp1.Service.Interface
{
    public interface IAccountService
    {

        Task<BaseResponse> RegisterUser(RegisterUserDto request);

        Task<BaseResponse> LoginUser(LoginUserDto request);
    }
}
