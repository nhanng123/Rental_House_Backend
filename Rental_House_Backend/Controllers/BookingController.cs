using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookingService.GetBookings());
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_bookingService.GetBooking(id));
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post(Booking booking)
        {
            return Ok(_bookingService.AddBooking(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok(_bookingService.ChangeState(id));
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bookingService.RemoveBooking(id));
        }
    }
}
