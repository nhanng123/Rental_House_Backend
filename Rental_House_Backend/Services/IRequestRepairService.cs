using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IRequestRepairService
    {
        List<RequestRepair> GetAllRepairs();
        List<RequestRepair> GetRoomRepairs(int roomId);
        RequestRepair GetRequestRepair(int id);
        Boolean AddRequestRepair(RequestRepair requestRepair);
        Boolean RemoveRequestRepair(int id);
        Boolean ChangeState(int id);
    }
}
