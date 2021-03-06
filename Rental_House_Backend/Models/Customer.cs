using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental_House_Backend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Id_Number { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        public string Hometown { get; set; }
        public string Initial_Address { get; set; }
        public string Job { get; set; }
        public string Nationality { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public string RoomName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Room Room { get; set; }

        
    }
}
