using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Room { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}
