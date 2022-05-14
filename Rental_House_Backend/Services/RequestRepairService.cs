using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class RequestRepairService : IRequestRepairService
    {
        private readonly RentalHouseDbContext repairDbContext;

        public RequestRepairService(RentalHouseDbContext rentalHouseDbContext_)
        {
            this.repairDbContext = rentalHouseDbContext_;
        }
        public bool AddRequestRepair(RequestRepair requestRepair)
        {
            repairDbContext.RequestRepair.Add(requestRepair);
            repairDbContext.SaveChanges();
            return true;
        }

        public bool ChangeState(int id, string state)
        {
            var request = GetRequestRepair(id);
            if (request == null)
            {
                return false;
            }

            request.Status = state;
            repairDbContext.RequestRepair.Update(request);
            repairDbContext.SaveChanges();
            return true;

        }

        public List<RequestRepair> GetAllRepairs()
        {
            return repairDbContext.RequestRepair.ToList();
        }

        public RequestRepair GetRequestRepair(int id)
        {
            return repairDbContext.RequestRepair.Find(id);
        }

        public List<RequestRepair> GetRoomRepairs(int roomId)
        {
            return repairDbContext.RequestRepair.Where(x => x.Room == roomId).ToList();
        }

        public bool RemoveRequestRepair(int id)
        {
            var repair = GetRequestRepair(id);
            if(repair == null)
            {
                return false;
            }

            repairDbContext.RequestRepair.Remove(repair);
            repairDbContext.SaveChanges();

            return true;
        }
    }
}
