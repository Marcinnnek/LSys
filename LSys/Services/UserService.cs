using LSys.DTOs;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.UOW;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LSys.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<UserDTO> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<UserDTO> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> RegisterUser(UserVM userVM)
        {
            if (!_unitOfWork.Users.CheckUserExist(userVM.Email))
            {
                UserDTO newUser = new UserDTO()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Description = userVM.Description,
                };

                var hashedPassword = _passwordHasher.HashPassword(newUser, userVM.Password);
                newUser.Password = hashedPassword;

                var roles = _unitOfWork.Roles.GetRoles().FirstOrDefault(r => r.Name == "User");

                newUser.Id =  (Guid)_unitOfWork.Users.Add(newUser); //tutaj user ma Id = 0, w funkcji add ma wygenerowane Id, nie jest "zwracane" do tego obiektu
                if (roles != null)
                {
                    _unitOfWork.UsersRoles.Add(new UserRoleListDTO { RoleId = roles.Id, UserId = newUser.Id });
                }
                else
                {
                    RoleDTO newRole = new RoleDTO()
                    {
                        Name = "Test"
                    };
                    _unitOfWork.Roles.Add(newRole);
                    _unitOfWork.UsersRoles.Add(new UserRoleListDTO { RoleId = newRole.Id, UserId = newUser.Id });
                }

                var result = await _unitOfWork.Complete();
                return result > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
