using LSys.DTOs;
using LSys.Services;
using LSys_DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace LSys.Controllers
{
    public class UserController : ControllerBase
    {
       // private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            // _unitOfWork = unitOfWork;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserVM userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(userDTO);
                return StatusCode(201); // Created
            }

            return NoContent();
        }


    }
    
}
