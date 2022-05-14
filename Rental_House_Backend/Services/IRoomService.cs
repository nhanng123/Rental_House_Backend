using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IRoomService
    {
        List<Room> GetRoom();
        Room GetOneRoom(int roomId);
        Boolean AddRoom(Room room);
        Boolean RemoveRoom(int roomId);
        Boolean UpdateRoom(Room room);
    }
}

