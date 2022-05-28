using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
