using LSys.Services;
using LSys.View_Models;
using LSys_DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace LSys.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccountService _userService;
        public AccountController(IAccountService userService)
        {
            _userService = userService;
        }

        [HttpGet("[controller]/RegisterUser")]
        public async Task<IActionResult> RegisterUser()
        {

            return View(new RegisterUserVM());
        }

        [HttpPost("[controller]/RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterUserVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerVM);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(registerVM);
            }

            return View(registerVM);
        }

        [HttpGet("[controller]/LogInUser")]
        public async Task<IActionResult> LogInUser()
        {
            return View(new LoginUserVM());
        }


        [HttpPost("[controller]/LogInUser")]
        public async Task<IActionResult> LogInUser([FromForm] LoginUserVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LogInUser(loginVM);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(loginVM);
            }

            return View(loginVM);

        }

        [HttpPost("[controller]/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutUser();
            return RedirectToAction("Index", "Home");
        }
    }
}
