using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roomService.GetRoom());
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_roomService.GetOneRoom(id));
        }

        // POST api/<RoomController>
        [HttpPost]
        public IActionResult Post(Room room)
        {
            return Ok(_roomService.AddRoom(room));
        }

        // PUT api/<RoomController>/5
        [HttpPut]
        public IActionResult Put(Room room)
        {
            return Ok(_roomService.UpdateRoom(room));
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_roomService.RemoveRoom(id));
        }
    }
}
