using LSys.DTOs;
using LSys.Exceptions;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LSys.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> RegisterUser(RegisterUserVM userVM)
        {
            //if (!_unitOfWork.Users.CheckUserExist(userVM.Email))
            //{
            //    UserDTO newUser = new UserDTO() // dodać automappera
            //    {
            //        UserName = userVM.UserName,
            //        Email = userVM.Email,
            //        Description = userVM.Description,
            //    };

            //    var hashedPassword = _passwordHasher.HashPassword(newUser, userVM.Password);
            //    newUser.PasswordHash = hashedPassword;

            //    var roles = _unitOfWork.Roles.GetRoles().FirstOrDefault(r => r.Name == "User");
            //    newUser.Id = (Guid)_unitOfWork.Users.Add(newUser); // UserDTO.Id Fixed

            //    if (roles != null)
            //    {
            //        _unitOfWork.UsersRoles.Add(new UserRoleListDTO { RoleId = roles.Id, UserId = newUser.Id });
            //    }
            //    else
            //    {
            //        RoleDTO newRole = new RoleDTO()
            //        {
            //            Name = "User"
            //        };
            //        _unitOfWork.Roles.Add(newRole);
            //        _unitOfWork.UsersRoles.Add(new UserRoleListDTO { RoleId = newRole.Id, UserId = newUser.Id });
            //    }

            //    var result = await _unitOfWork.Complete();
            //    return result > 0 ? true : false;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

       
    }


}
