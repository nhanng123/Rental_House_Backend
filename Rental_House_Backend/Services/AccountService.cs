using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class AccountService : IAccountService
    {
        private readonly RentalHouseDbContext accountDbContex;

        public AccountService(RentalHouseDbContext rentalHouseDbContext)
        {
            accountDbContex = rentalHouseDbContext;
        }

        public bool ChangePassword(string username, string oldPass, string newPass)
        {

            var account = accountDbContex.Account.Where(x => x.Username == username && x.Password == oldPass).FirstOrDefault();
            if (account == null)
            {
                return false;
            }
            account.Password = newPass;
            accountDbContex.Account.Update(account);
            accountDbContex.SaveChanges();
            return true;
        }
        public Account Login(string username, string password)
        {
            var isExist = accountDbContex.Account.Any(x => x.Username == username && x.Password == password);
            if (!isExist)
            {
                return null;
            }

            return accountDbContex.Account.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }

        public Account Register(int roomId)
        {
            var isExist = accountDbContex.Account.Any(x => x.RoomId == roomId);
            if ( isExist)
            {
                return null;
            }

            Account account = new Account();
            account.RoomId = roomId;
            account.Username = "guestroom" + roomId;
            account.Password = GetRandomString();
            if(roomId == 0)
            {
                account.Role = "admin";
            }
            else { account.Role = "guest"; }

            accountDbContex.Account.Add(account);
            accountDbContex.SaveChanges();

            return account;
        }

        public Account ResetPassword(int roomId)
        {
            var isExist = accountDbContex.Account.Any(x => x.RoomId == roomId);
            if (!isExist)
            {
                return null;
            }
            Account account = accountDbContex.Account.FirstOrDefault(x => x.RoomId == roomId);
            account.Password = GetRandomString();

            accountDbContex.Account.Update(account);
            accountDbContex.SaveChanges();

            return account;
        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); 
            return path;
        }
    }
}
