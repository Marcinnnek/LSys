using LSys.DTOs;
using LSys_DataAccess.Repository;
using LSys_DataAccess.UOW;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LSys.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> RegisterUser(UserVM userVM)
        {
            if (!_unitOfWork.Users.CheckUserExist(userVM.Email))
            {
                User newUser = new User()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Description = userVM.Description,
                };

                //                INSERT INTO[Users] ([Id], [Description], [Email], [Password], [UserName])
                //                VALUES(NEWID(), 'description test', 'mzuziak@gmail.com', 'passwordtest', 'Marcin');

                var hashedPassword = _passwordHasher.HashPassword(newUser, userVM.Password);
                newUser.Password = hashedPassword;

                //var roles = _unitOfWork.Roles.GetRoles().FirstOrDefault(r => r.Name == "User");
                Role roles = null;

                _unitOfWork.Users.Add(newUser);
                if (roles != null)
                {
                    _unitOfWork.UsersRoles.Add(new UserRoleList { RoleId = roles.Id, UserId = newUser.Id });
                }
                else
                {
                    Role newRole = new Role()
                    {
                        Name = "Test"
                    };
                    _unitOfWork.Roles.Add(newRole);
                    _unitOfWork.UsersRoles.Add(new UserRoleList { RoleId = newRole.Id, UserId = newUser.Id });
                }

                var result = await _unitOfWork.Complete();
                // _unitOfWork.Roles
                return result > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        //public async Task <bool> DeleteUser()
        //{
        //    bool result = false;
        //    return result;
        //}
    }
}
