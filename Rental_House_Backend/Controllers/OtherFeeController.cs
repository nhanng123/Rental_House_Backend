using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class OtherFeeController : ControllerBase
    {
        private readonly IOtherFeeServicecs otherFeeServicecs;

        public OtherFeeController(IOtherFeeServicecs otherFeeServicecs)
        {
            this.otherFeeServicecs = otherFeeServicecs;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public IActionResult Get(int id)
        {
            return Ok(otherFeeServicecs.GetOtherFee(id));
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(OtherFee otherFee) 
        {
            return Ok(otherFeeServicecs.UpdateOtherfee(otherFee)); 
        }

    }
}
