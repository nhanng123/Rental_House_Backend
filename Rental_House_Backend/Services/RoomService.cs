using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class RoomService : IRoomService
    {
        private readonly RentalHouseDbContext _roomDbContext;
        public RoomService(RentalHouseDbContext roomDbContext)
        {
            _roomDbContext = roomDbContext;
        }
        public bool AddRoom(Room room)
        {
            room.Date = DateTime.Today;
            _roomDbContext.Room.Add(room);
            _roomDbContext.SaveChanges();

            return true;
        }

        public List<Room> GetRoom()
        {
            return _roomDbContext.Room.ToList();
        }

        public Room GetOneRoom(int id)
        {
            Room room = _roomDbContext.Room.Find(id);
            return room;
        }

        public bool RemoveRoom(int id)
        {
            Room room = _roomDbContext.Room.Find(id);
            if(room != null || room.Number_Of_People != 0)
            {
                return false;
            }
            _roomDbContext.Room.Remove(room);
            _roomDbContext.SaveChanges();
            return true;
        }

        public bool UpdateRoom(Room room)
        {
            _roomDbContext.Room.Update(room);
            _roomDbContext.SaveChanges();
            return true;
        }
    }
}
