using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        List<Customer> GetRoomCustomers(int roomId);
        List<Customer> GetCurrentCustomers();
        List<Customer> GetOldCustomers();
        Customer GetCustomer(string customerId);
        Boolean AddCustomer(Customer customer);
        Boolean RemoveCustomer(string customerId);
        Boolean UpdateCustomer(string id,Customer customer);
        Boolean ChangeRoom(string customerId, int roomId);
    }
}
