using CoolPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = new User
            {
                Name = "Fredrik",
                Age = 25,
                Coolness = double.PositiveInfinity
            };
            return View(user);
        }
    }
}
