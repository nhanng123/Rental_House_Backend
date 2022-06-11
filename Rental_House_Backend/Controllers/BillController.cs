using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_House_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService _billService)
        {
           billService = _billService;
        }

        // GET: api/<BillController>
        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Get()
        {
            return Ok(billService.GetBillList());
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        [Route("/api/[Controller]/GetByRoom/{id}")]
        public IActionResult GetByRoom(int id)
        {
            return Ok(billService.GetRoomBills(id));
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "user,admin")]
        public IActionResult Get(int id)
        {
            return Ok(billService.GetBill(id));
        }

        [HttpGet]
        [Route("/api/[Controller]/room+electric/{id}")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetElectricBills(int id)
        {
            return Ok(billService.GetRoomElectricBills(id));
        }

        [HttpGet]
        [Route("/api/[Controller]/room+water/{id}")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetWaterBills(int id)
        {
            return Ok(billService.GetRoomWaterBills(id));
        }

        // POST api/<BillController>
        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public IActionResult Post(int roomId,int electric_num,int water_num)
        {
            return Ok(billService.AddBill(roomId, electric_num, water_num));
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult Put(int id)
        {
            return Ok(billService.Pay(id));
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            return Ok(billService.RemoveBill(id));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("/api/Bill/Profit")]
        public IActionResult GetProfit()
        {
            return Ok();
        }
    }
}
