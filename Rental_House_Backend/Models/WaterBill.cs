using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class WaterBill
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Water_Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime Water_Date { get; set; }
    }
}
