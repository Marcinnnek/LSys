using LSys.Services;
using LSys.View_Models;
using LSys_DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace LSys.Controllers
{
    public class AccountController : ControllerBase
    {
        // private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _userService;
        public AccountController(IAccountService userService)
        {
            _userService = userService;
            // _unitOfWork = unitOfWork;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerVM);
                return StatusCode(201); // Created
            }

            return NoContent();
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserVM loginVM)
        {
            //var token = await _userService.LoginUserAndGenrateJWTToken(loginVM);
            var token = "test";
            if (token != null)
            {
                return Ok(token);// Created
            }
            else
            {
                return NoContent();
            }

        }
    }
}
