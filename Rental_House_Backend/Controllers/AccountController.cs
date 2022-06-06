using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            this._userManager = userManager;

        }
        

        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> ChangePassword(string username, string password)
        {

            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                return BadRequest("Invalid Usrname");
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return Ok("Change password successfully!");
            }

            return BadRequest();

        }


        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> ResetPassword(string username,string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register(Account model)
        {
            if (ModelState.IsValid)
            {
               var user = new ApplicationUser { UserName = model.Username, Email = null, Room = model.RoomId };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var _user = await _userManager.FindByNameAsync(model.Username);
                    await _userManager.AddToRoleAsync(_user, "user");
                    return Ok("Reset password successfully!");
                }
            }
            return BadRequest(); 
        }


    }
}
