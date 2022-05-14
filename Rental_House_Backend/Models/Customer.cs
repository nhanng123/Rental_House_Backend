namespace Rental_House_Backend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Id_Number { get; set; }
        public DateTime DoB { get; set; }
        public string Initial_Address { get; set; }
        public string Job { get; set; }
        public string Nationality { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public int Room { get; set; }
    }
}
