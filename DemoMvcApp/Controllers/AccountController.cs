using DemoMvcApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(AccountDbContext context)
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
