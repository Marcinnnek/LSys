using LSys.DTOs;

namespace LSys.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserVM userDTO);
    }
}