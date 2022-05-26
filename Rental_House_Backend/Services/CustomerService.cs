﻿using Rental_House_Backend.Data;
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
            var otherfee = _customerDbContext.OtherFee.Find(3);
            room.Number_Of_People += 1;

            if (room.Number_Of_People == 1)
            {
                room.State = "Đã Cho Thuê";
            }
            else
            {
                if(room.Number_Of_People > 2)
                {
                    room.Price += otherfee.BonusPeopleFee;
                }
            }
           
            
            _customerDbContext.Room.Update(room);
            _customerDbContext.Customer.Add(customer);
            _customerDbContext.SaveChanges();
            return true;
        }

        public bool ChangeRoom(string customerId, int roomId)
        {
            Customer customer = _customerDbContext.Customer.Find(customerId);
            var otherfee = _customerDbContext.OtherFee.Find(3);
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
                    room.State = "Còn Trống";
                }
                else
                {
                    if( room.Number_Of_People >= 2)
                    {
                        room.Price -= otherfee.BonusPeopleFee;
                    }
                }
                customer.Room = 0;

                _customerDbContext.Room.Update(room);
            }
            else
            {
                customer.StartDate = DateTime.Today;
                customer.EndDate = DateTime.Today;
            }

            if (roomId != 0)
            {
                var toRoom = _customerDbContext.Room.Find(roomId);
                customer.Room = roomId;
                toRoom.Number_Of_People += 1;
               
                if (toRoom.Number_Of_People == 1)
                {
                    toRoom.State = "Đã Cho Thuê";
                }
                else
                {
                   if( toRoom.Number_Of_People > 2)
                    {
                        toRoom.Price += otherfee.BonusPeopleFee;
                    }
                }

                _customerDbContext.Room.Update(toRoom);
            }

            if (customer.Room == 0)
            {
                customer.EndDate = DateTime.Today;
               
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

        public Customer GetCustomer(string customerId)
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

        public bool RemoveCustomer(string customerId)
        {

            Customer cus = _customerDbContext.Customer.Find(customerId);
        
            if(cus.Room != 0)
            {
                var room = _customerDbContext.Room.Find(cus.Room);
                room.Number_Of_People--;
                if (room.Number_Of_People == 0)
                {
                    room.State = "Còn Trống";
                }
                else
                {
                    if(room.Number_Of_People > 2)
                    {
                        var otherfee = _customerDbContext.OtherFee.Find(1);
                        room.Price -= otherfee.BonusPeopleFee;
                    }
                }
                _customerDbContext.Room.Update(room);
            }
            
            _customerDbContext.Customer.Remove(cus);
            _customerDbContext.SaveChanges();
            return true;
        }

        public bool UpdateCustomer(String id,Customer customer)
        {
            if(id == customer.Id_Number)
            {
                _customerDbContext.Customer.Update(customer);
            }
            else
            {
                var cus = _customerDbContext.Customer.Find(id);
                _customerDbContext.Customer.Remove(cus);
                _customerDbContext.Customer.Add(customer);
            }
           
            _customerDbContext.SaveChanges();
            return true;
        }
    }
}
