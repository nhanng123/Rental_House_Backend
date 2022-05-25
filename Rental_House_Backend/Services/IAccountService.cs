using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IAccountService
    {
        Account Login(string username, string password);
        Account Register(int roomId);
        Boolean ChangePassword(string username, string oldPass,string newPass);
        Account ResetPassword(int roomId);

    }
}
