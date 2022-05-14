using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class RequestRepair
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
