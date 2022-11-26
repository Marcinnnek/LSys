using LSys_Domain;
using LSys_Domain.Entities;
using LSys_DataAccess.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSys_DataAccess.Repository;
using LSys_DataAccess.DTOs;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace LSys_DataAccess.Repository
{
    public class UserRepository : Repository<AppUser, UserDTO, Guid>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(LSysDbContext _DbContext, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(_DbContext, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDTO> CheckUserExist(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                _dbContext.Entry(user).State = EntityState.Detached;
                return userDTO;
            }
            else return null;
            //var result = _dbContext.Users.Where(u => u.Email == email).AsNoTracking();
            //return result.Count() > 0 ? true : false;
        }


        public async Task<bool> CreateUserAsync(UserDTO newUserDTO)
        {
            var newUser = _mapper.Map<AppUser>(newUserDTO);
            var newUserResponse = await _userManager.CreateAsync(newUser, newUser.PasswordHash);
            if (newUserResponse.Succeeded)
            {
                var roles = _dbContext.Roles.AsNoTracking().ToList();
                var defaultRole = roles.FirstOrDefault(r => r.Name == "User");
                var result = await _userManager.AddToRoleAsync(newUser, defaultRole.Name);
                if (result == IdentityResult.Success)
                {
                    return true;
                }
                else return false;

            }
            else return false;
        }
        public async Task<bool> CheckUserPassword(string password, UserDTO userDTO) 
        {
            var user = _mapper.Map<AppUser>(userDTO);
            var passwordCheck = await _userManager.CheckPasswordAsync(user, password);
            return passwordCheck;
        }
        public async Task<SignInResult> SignInUser(string password, UserDTO userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);
            var logInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            return logInResult;
        }

        public async Task LogOutUser()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
