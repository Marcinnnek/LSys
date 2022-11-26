using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IUserRepository : IRepository<AppUser, UserDTO, Guid>
    {
        Task<UserDTO> CheckUserExist(string email);
        Task<bool> CreateUserAsync(UserDTO newUserDTO);
        Task<bool> CheckUserPassword(string password, UserDTO userDTO);
        Task<SignInResult> SignInUser(string password, UserDTO userDTO);
        Task LogOutUser();
        //Task<bool> AddRoleToUser(UserDTO newUserDTO, string role);
        //public UserDTO GetUserWithRoles(string email);

    }
}
