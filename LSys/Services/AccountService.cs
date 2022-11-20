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
        private readonly IPasswordHasher<UserDTO> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IUnitOfWork unitOfWork, IPasswordHasher<UserDTO> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public async Task<bool> RegisterUser(RegisterUserVM userVM)
        {
            if (!_unitOfWork.Users.CheckUserExist(userVM.Email))
            {
                UserDTO newUser = new UserDTO() // dodać automappera
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Description = userVM.Description,
                };

                var hashedPassword = _passwordHasher.HashPassword(newUser, userVM.Password);
                newUser.PasswordHash = hashedPassword;

                var roles = _unitOfWork.Roles.GetRoles().FirstOrDefault(r => r.Name == "User");
                newUser.Id = (Guid)_unitOfWork.Users.Add(newUser); // UserDTO.Id Fixed

                if (roles != null)
                {
                    _unitOfWork.UsersRoles.Add(new UserRoleListDTO { RoleId = roles.Id, UserId = newUser.Id });
                }
                else
                {
                    RoleDTO newRole = new RoleDTO()
                    {
                        Name = "User"
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

        public async Task<string> LoginUserAndGenrateJWTToken(LoginUserVM loginVM)
        {
            var user = _unitOfWork.Users.GetUserWithRoles(loginVM.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginVM.Password);

            if (verifyPassword == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var userRoles = user.Roles;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               
            };
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }


}
