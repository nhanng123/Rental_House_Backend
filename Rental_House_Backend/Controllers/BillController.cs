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
        public IActionResult Get()
        {
            return Ok(billService.GetBillList());
        }

        [HttpGet]
        [Route("api/[Controller]/GetByRoom/{id}")]
        public IActionResult GetByRoom(int id)
        {
            return Ok(billService.GetRoomBills(id));
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(billService.GetBill(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetElectricBills(int id)
        {
            return Ok(billService.GetRoomElectricBills(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetWaterBills(int id)
        {
            return Ok(billService.GetRoomWaterBills(id));
        }

        // POST api/<BillController>
        [HttpPost]
        public IActionResult Post(int roomId,int electric_num,int water_num)
        {
            return Ok(billService.AddBill(roomId, electric_num, water_num));
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok(billService.Pay(id));
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(billService.RemoveBill(id));
        }
    }
}
