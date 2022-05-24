using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("api/[Controller]/current+customers")]
        public IActionResult GetCurrentCustomers()
        {
            return Ok(customerService.GetCurrentCustomers());
        }

        [HttpGet]
        [Route("api/[Controller]/old+customers")]
        public IActionResult GetOldCustomers()
        {
            return Ok(customerService.GetOldCustomers());
        }

        [HttpGet]
        [Route("api/[Controller]/GetByRoom/{id}")]
        public IActionResult GetRoomCustomer(int id)
        {
            return Ok(customerService.GetRoomCustomers(id));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(customerService.GetCustomer(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return Ok(customerService.AddCustomer(customer));
        }

        // PUT api/<ValuesController>
        [HttpPut]
        public IActionResult Put(String id,Customer customer)
        {
            return Ok(customerService.UpdateCustomer( id,customer));
        }

        [HttpPut("{id}")]
        public IActionResult changeRoom(String id, int roomId)
        {
            return Ok(customerService.ChangeRoom(id, roomId));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(customerService.RemoveCustomer(id));
        }
    }
}
