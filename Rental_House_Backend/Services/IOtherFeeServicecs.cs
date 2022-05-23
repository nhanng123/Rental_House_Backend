using Rental_House_Backend.Models;

namespace Rental_House_Backend.Services
{
    public interface IOtherFeeServicecs
    {
        OtherFee GetOtherFee(int id);
        Boolean UpdateOtherfee(OtherFee otherFee);
    }
}
