using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RentalHouseDbContext _customerDbContext;

        public CustomerService(RentalHouseDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public bool AddCustomer(Customer customer)
        {
            var room = _customerDbContext.Room.Find(customer.Room);
            var otherfee = _customerDbContext.OtherFee.Find(1);
            room.Number_Of_People += 1;

            if (room.Number_Of_People == 1)
            {
                room.State = "not available";
            }
            else
            {
                room.Price += otherfee.BonusPeopleFee;
            }
           

            _customerDbContext.Room.Update(room);
            _customerDbContext.Customer.Add(customer);
            _customerDbContext.SaveChanges();
            return true;
        }

        public bool ChangeRoom(int customerId, int roomId)
        {
            Customer customer = _customerDbContext.Customer.Find(customerId);
            var otherfee = _customerDbContext.OtherFee.Find(1);
            if (customer == null)
            {
                return false;
            }
            if(customer.Room != 0)
            {
                var room = _customerDbContext.Room.Find(customer.Room);
                room.Number_Of_People -= 1;

                if (room.Number_Of_People == 0)
                {
                    room.State = "available";
                }
                else
                {
                    room.Price -= otherfee.BonusPeopleFee;
                }
                customer.Room = 0;

                _customerDbContext.Room.Update(room);
            }

            if (roomId != 0)
            {
                var toRoom = _customerDbContext.Room.Find(roomId);
                customer.Room = roomId;
                toRoom.Number_Of_People += 1;
               
                if (toRoom.Number_Of_People == 1)
                {
                    toRoom.State = "not available";
                }
                else
                {
                    toRoom.Price += otherfee.BonusPeopleFee;
                }

                _customerDbContext.Room.Update(toRoom);
            }

            _customerDbContext.Customer.Update(customer);
            _customerDbContext.SaveChanges();
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDbContext.Customer.ToList();
        }

        public List<Customer> GetCurrentCustomers()
        {
            return _customerDbContext.Customer.Where(x => x.Room != 0).ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerDbContext.Customer.Find(customerId);
        }

        public List<Customer> GetOldCustomers()
        {
            return _customerDbContext.Customer.Where(x => x.Room == 0).ToList();
        }

        public List<Customer> GetRoomCustomers(int roomId)
        {
            return _customerDbContext.Customer.Where(x => x.Room==roomId).ToList();
        }

        public bool RemoveCustomer(int customerId)
        {

            Customer cus = _customerDbContext.Customer.Find(customerId);
        
            var room = _customerDbContext.Room.Find(cus.Room);
            room.Number_Of_People --;
            if(room.Number_Of_People == 0)
            {
                room.State = "available";
            }
            else
            {
                var otherfee = _customerDbContext.OtherFee.Find(1);
                room.Price -= otherfee.BonusPeopleFee;
            }
            
            _customerDbContext.Customer.Remove(cus);
            _customerDbContext.Room.Update(room);
            _customerDbContext.SaveChanges();
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _customerDbContext.Customer.Update(customer);
            _customerDbContext.SaveChanges();
            return true;
        }
    }
}
