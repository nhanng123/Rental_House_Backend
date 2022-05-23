using Rental_House_Backend.Data;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public class OtherFeeService : IOtherFeeServicecs

    {
        private readonly RentalHouseDbContext _otherfeeDbContext;

        public OtherFeeService(RentalHouseDbContext rentalHouseDbContext)
        {
            _otherfeeDbContext = rentalHouseDbContext;
        }
        public OtherFee GetOtherFee(int id)
        {
            return _otherfeeDbContext.OtherFee.Find(id);
        }

        public bool UpdateOtherfee(OtherFee otherFee)
        {
           _otherfeeDbContext.OtherFee.Update(otherFee);
            _otherfeeDbContext.SaveChanges();
            return true;
        }
    }
}
