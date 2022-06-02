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
        // GET: api/<AccountController>
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return Ok(_accountService.Login(username, password));
        }


        // POST api/<AccountController>
        [HttpPost("{id}")]
        public IActionResult Regiter(int id)
        {
            return Ok(_accountService.Register(id));
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account model)
        {
            if (ModelState.IsValid)
            {
               var user = new ApplicationUser { UserName = model.Username, Email = null };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest(); 
        }

        [HttpPost]
        [Route("api/[Controller]/ResetPass/{id}")]
        public IActionResult ResetPassword(int id)
        {
            return Ok(_accountService.ResetPassword(id));
        }



        // PUT api/<AccountController>/5
        [HttpPut]
        public IActionResult ChangePassword(string username, string oldPass, string newPass)
        {
            return Ok(_accountService.ChangePassword(username, oldPass, newPass));
        }


    }
}
