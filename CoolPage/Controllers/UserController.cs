using CoolPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolPage.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var user = new User
            {
                Name = "Pedro",
                Age = 25,
                Coolness = double.PositiveInfinity
            };
            return View(user);
        }
    }
}
