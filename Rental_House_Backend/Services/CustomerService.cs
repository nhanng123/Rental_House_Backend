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
            room.Number_Of_People += 1;

            if (room.Number_Of_People > 0)
            {
                room.State = "not available";
            }

            _customerDbContext.Room.Update(room);
            _customerDbContext.Customer.Add(customer);
            _customerDbContext.SaveChanges();
            return true;
        }

        public bool ChangeRoom(int customerId, int roomId)
        {
            Customer customer = _customerDbContext.Customer.Find(customerId);
            if (customer == null)
            {
                return false;
            }
            var room = _customerDbContext.Room.Find(customer.Room);
            room.Number_Of_People -= 1;
            if (room.Number_Of_People == 0)
            {
                room.State = "available";
            }

            customer.Room = 0;

            if (roomId != 0)
            {
                var toRoom = _customerDbContext.Room.Find(roomId);
                customer.Room = roomId;
                toRoom.Number_Of_People += 1;
                if (toRoom.Number_Of_People != 0)
                {
                    toRoom.State = "not available";
                }

                _customerDbContext.Room.Update(toRoom);
            }

            _customerDbContext.Room.Update(room);
            _customerDbContext.Customer.Update(customer);
            _customerDbContext.SaveChanges();
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDbContext.Customer.ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerDbContext.Customer.Find(customerId);
        }

        public List<Customer> GetRoomCustomers(int roomId)
        {
            return _customerDbContext.Customer.Where(x => x.Room==roomId).ToList();
        }

        public bool RemoveCustomer(int customerId)
        {
            Customer cus = _customerDbContext.Customer.Find(customerId);
            _customerDbContext.Customer.Remove(cus);
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
