using Microsoft.AspNetCore.Identity;

namespace Rental_House_Backend.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Room { get; set; }
    }
}
