using CoolPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoolPage.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = new User
            {
                Name = "Fredrik",
                Age = 25,
                Coolness = double.PositiveInfinity
            };

            await HeavyWorkAsync();

            return View(user);
        }

        private static void HeavyWork()
        {
            for (int i = 0; i < 2000000000; i++)
            {

            }
        }

        private static async Task HeavyWorkAsync()
        {
            await Task.Run(() => HeavyWork());
        }
    }
}
