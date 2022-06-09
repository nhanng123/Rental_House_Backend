using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class BillService : IBillService
    {
        private readonly RentalHouseDbContext billDbContext;

        public BillService(RentalHouseDbContext billDbContext)
        {
            this.billDbContext = billDbContext;
        }
        public bool AddBill(int roomId, int electric_num, int water_num)
        {
            var otherfee = billDbContext.OtherFee.Find(1);
            var room = billDbContext.Room.Find(roomId);
            DateTime today = DateTime.Today;
            var pre_elec_num = billDbContext.ElectricBill.OrderByDescending(x => x.Id).FirstOrDefault(x => x.RoomId == roomId);
            var pre_water_num = billDbContext.WaterBill.OrderByDescending(x => x.Id).FirstOrDefault(x => x.RoomId == roomId);


            Bill bill = new Bill();
            bill.Room = roomId;
            bill.Price = (int)room.Price;
            bill.Time = today;
            bill.Electric_Num = electric_num - (pre_elec_num != null ? pre_elec_num.Electric_Number : 0);
            bill.Electric_Fee = bill.Electric_Num * otherfee.ElectricFee;
            bill.Water_Num = water_num - (pre_water_num != null ? pre_water_num.Water_Number : 0);
            bill.Water_Fee = bill.Water_Num * otherfee.WaterFee;
            bill.Wifi_Fee = otherfee.WifiFee;
            bill.Garbage_Fee = otherfee.GarbageFee;
            bill.Total = bill.Garbage_Fee + bill.Wifi_Fee + bill.Water_Fee + bill.Electric_Fee + bill.Price;
            bill.Is_Pay = false;
            billDbContext.Bill.Add(bill);
            billDbContext.SaveChanges();

            var bill_ = billDbContext.Bill.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Room == roomId);

            ElectricBill electricBill = new ElectricBill() { BillId = bill_.Id };
          
            electricBill.RoomId = roomId;
            electricBill.Old_Number = (pre_elec_num != null ? pre_elec_num.Electric_Number : 0);
            electricBill.Electric_Number = electric_num;
            electricBill.Electric_Price = otherfee.ElectricFee;
            electricBill.Total = bill.Electric_Fee;
            electricBill.Electric_Date = today;
            billDbContext.ElectricBill.Add(electricBill);

            WaterBill waterBill = new WaterBill() { BillId = bill_.Id };
           
            waterBill.RoomId = roomId;
            waterBill.Old_Number = (pre_water_num != null ? pre_water_num.Water_Number : 0);
            waterBill.Water_Number = water_num;
            waterBill.Price = otherfee.WaterFee;
            waterBill.Total = bill.Water_Fee;
            waterBill.Water_Date = today;
            billDbContext.WaterBill.Add(waterBill);


            billDbContext.SaveChanges();
            return true;
        }

        public Bill GetBill(int id)
        {

            return billDbContext.Bill.FirstOrDefault(b => b.Id == id);
        }

        public bool RemoveBill(int id)
        {
            Bill bill = GetBill(id);
            var pre_elec_num = billDbContext.ElectricBill.FirstOrDefault(x => x.BillId == id);
            var pre_water_num = billDbContext.WaterBill.FirstOrDefault(x => x.BillId == id);


            billDbContext.Bill.Remove(bill);
            if(pre_elec_num != null && pre_water_num != null)
            {
                billDbContext.ElectricBill.Remove(pre_elec_num);
                billDbContext.WaterBill.Remove(pre_water_num);
            }
            billDbContext.SaveChanges();
            return true;
        }

        public bool UpdateBill(Bill bill)
        {
            billDbContext.Bill.Update(bill);
            billDbContext.SaveChanges();
            return true;
        }

        public bool Pay(int id)
        {
            var bill = GetBill(id);
            bill.Is_Pay = true;
            billDbContext.Bill.Update(bill);
            billDbContext.SaveChanges();
            return true;
        }

        public List<Bill> GetRoomBills(int roomId)
        {
            return billDbContext.Bill.Where(x => x.Room == roomId).ToList();

        }

        public Bill[] GetBillList()
        {
            return billDbContext.Bill.ToArray();
        }

        public List<ElectricBill> GetRoomElectricBills(int roomId)
        {
            return billDbContext.ElectricBill.Where(x => x.RoomId == roomId).ToList();
        }

        public List<WaterBill> GetRoomWaterBills(int roomId)
        {
            return billDbContext.WaterBill.Where(x => x.RoomId == roomId).ToList();
        }
    }
}
