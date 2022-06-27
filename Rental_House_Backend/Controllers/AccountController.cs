using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Data;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RentalHouseDbContext _context;

        public AccountController( UserManager<ApplicationUser> userManager, RentalHouseDbContext _context)
        {
          
            this._userManager = userManager;
            this._context = _context;

        }


        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> ChangePassword(string password)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return Ok("Change password successfully!");
            }

            return BadRequest();

        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ResetPassword(string username, string password)
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
            var user = new ApplicationUser { UserName = model.Username, Email = null, Room = model.RoomId };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var _user = await _userManager.FindByNameAsync(model.Username);
                await _userManager.AddToRoleAsync(_user, "user");
                return Ok("Reset password successfully!");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok( _context.Users.ToList());
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                return BadRequest(false);
            }
            await _userManager.DeleteAsync(user);
            return Ok(true);
        }

    }
}
