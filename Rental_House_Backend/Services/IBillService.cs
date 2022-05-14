using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IBillService
    {
        Bill[] GetBillList();
        List<Bill> GetRoomBills(int roomId);
        Bill GetBill(int id);
        Boolean AddBill(int roomId, int elctric, int water);
        Boolean UpdateBill(Bill bill);
        Boolean RemoveBill(int id);
        Boolean Pay(int id);
    }
}
