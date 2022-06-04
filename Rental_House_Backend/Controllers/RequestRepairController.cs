using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestRepairController : ControllerBase
    {
        private readonly IRequestRepairService requestRepairService;

        public RequestRepairController(IRequestRepairService requestRepairService_)
        {
            requestRepairService = requestRepairService_;
        }
        // GET: api/<RequestRepairController>
        [HttpGet]
         [Authorize(Roles ="admin")]
        public IActionResult Get()
        {
            return Ok(requestRepairService.GetAllRepairs());
        }

        [HttpGet]
        [Route("/api/[controller]/RoomRepairs/{id}")]
        public IActionResult GetRoomRepairs(int id)
        {
            return Ok(requestRepairService.GetRoomRepairs(id));
        }

        // GET api/<RequestRepairController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok(requestRepairService.GetRequestRepair(id));
        }

        // POST api/<RequestRepairController>
        [HttpPost]
        public IActionResult Post(RequestRepair requestRepair)
        {
            return Ok(requestRepairService.AddRequestRepair(requestRepair));
        }

        // PUT api/<RequestRepairController>/5
        [HttpPut("{id}")]
         [Authorize(Roles ="admin")]
        public IActionResult Put(int id)
        {
            return Ok(requestRepairService.ChangeState(id));
        }

        // DELETE api/<RequestRepairController>/5
        [HttpDelete("{id}")]
         [Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            return Ok(requestRepairService.RemoveRequestRepair(id));
        }
    }
}
