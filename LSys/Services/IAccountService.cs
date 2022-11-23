using LSys.View_Models;

namespace LSys.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterUser(RegisterUserVM userDTO);
        
    }
}