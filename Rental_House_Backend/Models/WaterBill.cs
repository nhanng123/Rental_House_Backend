using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class WaterBill
    {
        public int Id { get; private set; }
        public int RoomId { get; set; }
        public int Old_Number { get; set; }
        public int Water_Number { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        [DataType(DataType.Date)]
        public DateTime Water_Date { get; set; }
    }
}
