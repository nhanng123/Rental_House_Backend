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
    
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoomController(IRoomService roomService, UserManager<ApplicationUser> userManager)
        {
            _roomService = roomService;
            this._userManager = userManager;
        }

        // GET: api/<RoomController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_roomService.GetRoom());
        }

        // GET api/<RoomController>/5
        [HttpGet]
        [Route("/api/[Controller]/GetRoomById")]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> GetRoomByID()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if(user.Room == 0)
            {
                return Ok(null);
            }
            return Ok(_roomService.GetOneRoom(user.Room));
        }

        // POST api/<RoomController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post(Room room)
        {
            return Ok(_roomService.AddRoom(room));
        }

        // PUT api/<RoomController>/5
        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateRoom(Room room)
        {
            
            return Ok(_roomService.UpdateRoom(room));
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            return Ok(_roomService.RemoveRoom(id));
        }
    }
}
`       