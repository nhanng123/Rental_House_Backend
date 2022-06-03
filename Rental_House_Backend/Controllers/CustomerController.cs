using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(ICustomerService customerService, UserManager<ApplicationUser> userManager)
        {
            this.customerService = customerService;
            this._userManager = userManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
       
        public async Task<IActionResult> Get()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || ! await _userManager.IsInRoleAsync(user,"admin"))
            {
                return BadRequest();
            }

            return Ok(customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("/api/[Controller]/current+customers")]
        
        public async Task<IActionResult> GetCurrentCustomers()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return BadRequest();
            }
            return Ok(customerService.GetCurrentCustomers());
        }

        [HttpGet]
        [Route("/api/[Controller]/old+customers")]
       
        public async Task<IActionResult> GetOldCustomers()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return BadRequest();
            }
            return Ok(customerService.GetOldCustomers());
        }

        [HttpGet]
        [Route("/api/[Controller]/GetByRoom/{id}")]
        public IActionResult GetRoomCustomer(int id)
        {
            return Ok(customerService.GetRoomCustomers(id));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(customerService.GetCustomer(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        
        public async Task<IActionResult> Post(Customer customer)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return BadRequest();
            }
            return Ok(customerService.AddCustomer(customer));
        }

        // PUT api/<ValuesController>
        [HttpPut]
        [Route("/api/[Controller]/Edit/{id}")]
        public IActionResult Put(int id,Customer customer)
        {
            return Ok(customerService.UpdateCustomer( id,customer));
        }

        [HttpPut("{id}")]
       
        public async Task<IActionResult> changeRoom(int id, int roomId)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return BadRequest();
            }
            return Ok(customerService.ChangeRoom(id, roomId));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> Delete(int roomId)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || !await _userManager.IsInRoleAsync(user, "admin"))
            {
                return BadRequest();
            }
            return Ok(customerService.RemoveCustomer(roomId));
        }
    }
}
