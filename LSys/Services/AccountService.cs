using LSys.DTOs;
using LSys.Exceptions;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.UOW;
//using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace LSys.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;

        //private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IUnitOfWork unitOfWork) //, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
        {
            _unitOfWork = unitOfWork;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }



        public async Task<bool> RegisterUser(RegisterUserVM registerVM)
        {
            //var user = await _userManager.FindByNameAsync(registerVM.Email);

            var user = await _unitOfWork.Users.CheckUserExist(registerVM.Email);
            if (user != null)
            {
                return false;
            }
            var newUser = new UserDTO
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
                PasswordHash = registerVM.Password
            };

            bool result = await _unitOfWork.Users.CreateUserAsync(newUser);

            return result;
        }


        public async Task<bool> LogInUser(LoginUserVM loginVM)
        {
            var user = await _unitOfWork.Users.CheckUserExist(loginVM.Email);
            if (user != null)
            {
                var passwordCheck = await _unitOfWork.Users.CheckUserPassword(loginVM.Password, user);
                if (passwordCheck == true)
                {
                    var logInResult = await _unitOfWork.Users.SignInUser(loginVM.Password, user);
                    return logInResult.Succeeded ? true : false;
                }
            }
            return true;
        }

        public async Task LogOutUser()
        {
            await _unitOfWork.Users.LogOutUser();
        }

    }


}
