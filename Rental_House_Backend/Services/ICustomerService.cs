using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        List<Customer> GetRoomCustomers(int roomId);
        List<Customer> GetCurrentCustomers();
        List<Customer> GetOldCustomers();
        Customer GetCustomer(int customerId);
        Boolean AddCustomer(Customer customer);
        Boolean RemoveCustomer(int customerId);
        Boolean UpdateCustomer(Customer customer);
        Boolean ChangeRoom(int customerId, int roomId);
    }
}
