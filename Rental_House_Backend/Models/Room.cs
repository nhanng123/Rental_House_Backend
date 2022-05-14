namespace Rental_House_Backend.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Number_Of_People { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
