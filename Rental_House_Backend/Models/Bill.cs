using System.ComponentModel.DataAnnotations;

namespace Rental_House_Backend.Models
{
    public class Bill
    {
        public int Id { get; private set; }
        public int Room { get; set; }
        public int Price { get; set; }
        public string RoomName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        public int Electric_Num { get; set; }
        public int Electric_Fee { get; set; }
        public int Water_Num { get; set; }
        public int Water_Fee { get; set; }
        public int Garbage_Fee { get; set; }
        public int Wifi_Fee { get; set; }
        public int Total { get; set; }
        public bool Is_Pay { get; set; }
    }
}
