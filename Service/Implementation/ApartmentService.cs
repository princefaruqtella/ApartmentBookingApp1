using ApartmentBookingApp1.Dto;
using ApartmentBookingApp1.Dto.Client;
using ApartmentBookingApp1.Models;
using ApartmentBookingApp1.Repositories.Interfaces;
using ApartmentBookingApp1.Data.Entities;
using ApartmentBookingApp1.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace ApartmentBookingApp1.Service.Implementation
{
    public class ApartmentService(IApartmentRepository _apartmentRepository, IWebHostEnvironment _webhost) : IApartmentService
    {
        public BaseResponse RegisterApartment(RegisterApartmentDto apartmentDto)
        {
           var ImageName = "";
           Console.WriteLine($" apartmentDto.Image     {apartmentDto.Image}");
           if (apartmentDto.Image != null)
           {
            // Console.WriteLine($" apartmentDto.Image     {apartmentDto.Image}");
               var path = _webhost.WebRootPath;
               var imagepath = Path.Combine(path, "Images");
               Directory.CreateDirectory(imagepath);
               var imagetype = apartmentDto.Image.ContentType.Split('/')[1];
               if(imagetype != "png" && imagetype != "jpg" && imagetype != "jpeg")
               {
                  return new BaseResponse (false, "400", "An error occoured, the file type is not an Image");
               }
               ImageName = $"{Guid.NewGuid()}.{imagetype}";
               var fullpath = Path.Combine(imagepath, ImageName);
               using (var stream = new FileStream(fullpath, FileMode.Create))
               {
                    apartmentDto.Image.CopyTo(stream);
               }
           }

            
            var apartment = new Apartment
            {
                Address = apartmentDto.Address,
                LocalGovernment = apartmentDto.LocalGovernment,
                ApartmentPrice = apartmentDto.ApartmentPrice,
                OtherCharges = apartmentDto.OtherCharges,
                NumberOfRooms = apartmentDto.NumberOfRooms,
                Image = ImageName,
            };
           int changes = _apartmentRepository.AddApartment(apartment);
            if(changes < 0)
            {
                return new BaseResponse(false, "500", "An error occured, Pls try again");
            }
            return new BaseResponse(true, "200", "Registeration successful");
        }
        public async  Task<List<ApartmentDto>> GetAllApartments()
        {
            var apartments = _apartmentRepository.GetAllApartments();
            List<ApartmentDto> apartmentDto = new();
            foreach (var apartment in apartments)
             {
                apartmentDto.Add(new ApartmentDto{
                Address = apartment.Address,
                LocalGovernment = apartment.LocalGovernment,
                ApartmentPrice = apartment.ApartmentPrice,
                OtherCharges = apartment.OtherCharges,
                NumberOfRooms = apartment.NumberOfRooms,
                Image = apartment.Image
            });
            }
            return apartmentDto;
        }
    }
}


// namespace ApartmentBookingApp1.Service.Implementation
// {
//     public class ApartmentService : IApartmentService
//     {
//         private readonly IApartmentRepository _apartmentRepository;

//         public ApartmentService(IApartmentRepository apartmentRepository)
//         {
//             _apartmentRepository = apartmentRepository;
//         }

//         public BaseResponse AddApartment(ApartmentDto apartmentDto)
//         {
//             var apartment = new Apartment
//             {
//                 Name = apartmentDto.Name,
//                 Address = apartmentDto.Address,
//                 NumberOfRooms = apartmentDto.NumberOfRooms,
//                 Price = apartmentDto.Price
//             };

//             int changes = _apartmentRepository.AddApartment(apartment);
//             if (changes < 0)
//             {
//                 return new BaseResponse(false, "500", "An error occurred, please try again");
//             }

//             return new BaseResponse(true, "200", "Apartment added successfully");
//         }

//         public async Task<List<ApartmentDto>> GetAllApartments()
//         {
//             var apartments = await _apartmentRepository.GetAllApartmentsAsync();
//             List<ApartmentDto> apartmentDtos = new();
            
//             foreach (var apartment in apartments)
//             {
//                 apartmentDtos.Add(new ApartmentDto
//                 {
//                     Id = apartment.Id,
//                     Name = apartment.Name,
//                     Address = apartment.Address,
//                     NumberOfRooms = apartment.NumberOfRooms,
//                     Price = apartment.Price
//                 });
//             }

//             return apartmentDtos;
//         }
//     }
// }