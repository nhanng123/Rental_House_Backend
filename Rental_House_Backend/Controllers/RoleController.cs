using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Controllers
{
  
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;

        public RoleController(UserManager<ApplicationUser> usermanager)
        {
            this._usermanager = usermanager;
        }
        [Route("Role/Index")]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByNameAsync("nhn@g.com");
            await _usermanager.AddToRoleAsync(user, "admin");
           
            return View();
        }
    }
}
