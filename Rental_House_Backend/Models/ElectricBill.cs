using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class ElectricBill
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Electric_Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime Electric_Date { get; set; }
    }
}

