using HotelListing.Models;

namespace HotelListing.Services
{
    public interface IAuthManager
    {

        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();

    }
}
