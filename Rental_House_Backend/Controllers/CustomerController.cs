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
    [ApiController]
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
       [Authorize(Roles ="admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("/api/[Controller]/current+customers")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetCurrentCustomers()
        {
            return Ok(customerService.GetCurrentCustomers());
        }

        [HttpGet]
        [Route("/api/[Controller]/old+customers")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetOldCustomers()
        {
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(Customer customer)
        {
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> changeRoom(int id, int roomId)
        {
            return Ok(customerService.ChangeRoom(id, roomId));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(customerService.RemoveCustomer(id));
        }
    }
}
